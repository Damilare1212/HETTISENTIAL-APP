using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace HettisentialMvc
{
    public class UserController : Controller
    {
        private readonly IUserService _UserService;
        public readonly IWebHostEnvironment _WebhostEnvironment;

        public UserController (IUserService userService, IWebHostEnvironment WebhostEnvironmenty)
		{
			_UserService = userService;
			_WebhostEnvironment = WebhostEnvironmenty;
		}
       

       	[HttpGet]
		public IActionResult Index()
		{	
			return View();
		}
		
		
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public    IActionResult Login (LoginRequestModel Request)
		{

			//  if (string.IsNullOrEmpty(Request.PassWord) && !string.IsNullOrEmpty(Request.Email))
            // {
            //     return Content(  
            //         "<script> alert('Invalid Email or Password') </script>"  
            //     ); 
            // }


			var user =  _UserService.LogInUser(Request);
			if (user.Data != null)
			{
				var claims = new List<Claim>
				{
					new Claim (ClaimTypes.NameIdentifier, user.Data.Id.ToString()),
					new Claim (ClaimTypes.Email, user.Data.Email),
					new Claim (ClaimTypes.Name, $"{user.Data.UserFirstName} {user.Data.UserLastName} ")
					//new  Claim (ClaimTypes.Role, $"{user.Data.Roles}")
					//new Claim 
				};

				foreach (var it in user.Data.Roles)
				{
					claims.Add(new Claim(ClaimTypes.Role, it.RoleName));
				}

				var ClaimsIdentity =  new ClaimsIdentity
				(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				 var authenticationProperties = new AuthenticationProperties();
				var principal = new ClaimsPrincipal
				(ClaimsIdentity); 

				  HttpContext.SignInAsync
				(CookieAuthenticationDefaults.AuthenticationScheme,principal,authenticationProperties );
				 TempData["Success"] = "Successfully LogIn";
				if (user.Status == true)
				{
					
					if (user.Data.Roles.Select(h=> h.RoleName).Contains("Admin" ))
					return RedirectToAction ("Index", "Admin");

						else if(user.Data.Roles.Select(h=> h.RoleName).Contains("Patients" ))
					return RedirectToAction ("Index", "Home");

						else if(user.Data.Roles.Select(h=> h.RoleName).Contains("Hospital" ))
				return RedirectToAction ("Index", "Admin");

							else if(user.Data.Roles.Select(h=> h.RoleName).Contains("Pharmacy" ))
					return RedirectToAction ("Index", "Home");


						  
					
				}
				
			   
			}
			 ViewBag.error = "Invalid Email Or PassWord";
			 return View();

		}  
		public IActionResult Logout()
		{
			HttpContext.SignOutAsync
			(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction ("Index", "Home" );
		}

		[HttpGet]
		public IActionResult GetAllUsers()
		{
			var Users = _UserService.GetAll();
			return View(Users);
		}
		
		[HttpGet]
		public IActionResult Delete (int id)
		{
			var user = _UserService. DeleteUser(id);
			if (user != null)
			{
				return View(user);
			}
			return NotFound();
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleTe(int id)
		{
			_UserService. DeleteUser(id);
			return RedirectToAction ( "Index" );
		}
    }
}