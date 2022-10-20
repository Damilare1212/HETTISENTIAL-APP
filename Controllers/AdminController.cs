using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace HettisentialMvc
{
    public class AdminController : Controller
    {
        private readonly IApplicationAdminService _AdminService;
        public AdminController(IApplicationAdminService adminService)
        {
            _AdminService = adminService;
        }

        [HttpGet]
        public IActionResult Index()
        {
              return View();
        }

         [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(CreateAdminRequestModel model)
        {
            _AdminService.Create(model);
            return RedirectToAction("Login", "User" );
        }

        [HttpGet]
         public IActionResult Update(int id)
        {
            var admin = _AdminService.ReturnById(id);
            if (admin == null)
            {
                return NotFound();
            }
            return View();
        }
        
        [HttpPost]
        public IActionResult Update (UpdateAdminRequestModel model,int id)
        {
            _AdminService.Update(model, id);
            return RedirectToAction("GetAll");

        }

           [HttpGet]
        public IActionResult Delete(int id)
        {

            var admin = _AdminService.ReturnById(id);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin.Data);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _AdminService.Delete(id);
            return RedirectToAction("GetAll");
        }

        
        [HttpGet]
         public IActionResult Details(int id)
        {
            var admin = _AdminService.ReturnById(id);
            return View(admin.Data);
        }
        [HttpGet]
        public IActionResult EmailDetail(string Email)
        {
            var admin = _AdminService.GetByEmail(Email);
            return View(admin.Data);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var admin = _AdminService.GetAll();
            return View(admin.Data);
        }
        [HttpGet]
        public IActionResult Profile(int id)
        {
            var res = _AdminService.GetByEmail(User.FindFirst(ClaimTypes.Email).Value);
            var admin = _AdminService.ReturnById(res.Data.Id);
            return View(admin.Data);
        }

   
    }
}