

using Microsoft.AspNetCore.Mvc;

namespace HettisentialMvc
{
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressController (IAddressService Adderesservice)
        {  
            _addressService = Adderesservice;
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
        public IActionResult Create(CreateAddressRequestModel model)
        {
            _addressService.Create(model);
           // return RedirectToAction("Index", "Home" );
             return RedirectToAction("Login", "User" );
        }
        
           [HttpGet]
         public IActionResult Update(int id)
        {
            var admin = _addressService.ReturnById(id);
            if (admin == null)
            {
                return NotFound();
            }
            return View();
        }
        
        [HttpPost]
        public IActionResult Update (UpdateAddressRequestModel model,int id)
        {
            _addressService.Update(model, id);
            return RedirectToAction("GetAll");
        }

        

    }
}