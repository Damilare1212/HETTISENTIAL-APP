using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HettisentialMvc
{
    public class RoleController : Controller
    {
         private readonly IRoleService _roleservice;


           public RoleController(IRoleService roleservice)
        {
            _roleservice = roleservice;
        }

          [HttpGet]
        public IActionResult Index()
        {
            return View();
        }      
        
         [Authorize (Roles = "Admin")]
         [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
       
        public IActionResult Create( CreateRoleRequestModel model)
        {
            var roled = _roleservice.Create(model);
            return RedirectToAction("Admin", "Index");
           
        }
        [Authorize(Roles="Admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {

            var roled = _roleservice.ReturnById(id);
            if (roled == null)
            {
                return NotFound();
            }
            return View(roled.Data);
        }
        
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _roleservice.Delete(id);
            return RedirectToAction("Index");
        }

        [Authorize(Roles="Admin")]
        [HttpGet]
        public IActionResult GetAllRoles()
        {
            var roles = _roleservice.GetAll();
            return View(roles.Data);
        }

        [Authorize(Roles="Admin")]
         [HttpGet]
        public IActionResult Details(int id)
        {
            var hospital = _roleservice.ReturnById(id);
            return View(hospital.Data);
        }

        
        [Authorize(Roles="Admin")]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var roled = _roleservice.ReturnById(id);
            if (roled == null)
            {
                return NotFound();
            }
            return View();
        }
        
        [HttpPost]
        public IActionResult Update(int id,  UpdateRoleRequestModel model)
        {
            var roled = _roleservice.Update(model, id);
            return View(roled);
        }
    }
}