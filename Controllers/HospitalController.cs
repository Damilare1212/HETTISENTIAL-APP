using System.Security.Claims;
using System.Threading.Tasks;
using HettisentialMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace HettisentialMvc
{
    public class HospitalController : Controller
    {
         private readonly  IHealthCenterService _hospitalservice; 
          private readonly ApplicationContext _Conext;
         public HospitalController (ApplicationContext conext,  IHealthCenterService hospialService)
         {
            _hospitalservice = hospialService;
            _Conext = conext;
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


          [HttpGet]
           public  async Task< IActionResult> Search(string text)
           {
                 ViewData["MySearch"] = text;
                var query = from s in _Conext.Hospitals 

                select s ;
                   
                       
                 if (!string.IsNullOrEmpty(text))
                 {
                    query = query.Where(x => x.Name.Contains(text) || x.Country.Contains(text) || x.Email.Contains(text)   );
                 }

                 return View (await query.AsNoTracking().ToListAsync());
                       
                         

           }


        [HttpPost]
        public IActionResult Create(CreateHospitalRequestModel model)
        {
            _hospitalservice.Register(model);           
            
            TempData["HospitalCreation"] = "Hospital Successfully Registered";
           // return RedirectToAction("LogIn", "User");
             return RedirectToAction("Index", "Home" );
        }
             [HttpGet]
        public IActionResult Update(int id)
        {
            var hosp = _hospitalservice. GetHospital(id);
            if (hosp == null)
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Update(int id, UpdateHospitalRequestModel model)
        {
            _hospitalservice.Update(model, id);
            return RedirectToAction("GetAllHospital");
        }

           [HttpGet]
       // [Authorize(Roles="Admin")]
        public IActionResult Delete(int id)
        {

            var hospital = _hospitalservice.GetHospital(id);
            if (hospital == null)
            {
                return NotFound();
            }
            return View(hospital.Data);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _hospitalservice.Delete(id);
            return RedirectToAction("GetAllHospital");
        }
        [HttpGet]
        public IActionResult GetAllHospital()
        {
            var hospitals = _hospitalservice.GetAllHospital();
            return View(hospitals.Data);
        }
        [HttpGet]
       // [Authorize(Roles="Admin")]
        public IActionResult Details(int id)
        {
            var hospital = _hospitalservice.GetHospital(id);
            return View(hospital.Data);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Profile()
        {
            var res = _hospitalservice.GetByMail(User.FindFirst(ClaimTypes.Email).Value);
            var hospital = _hospitalservice.GetHospital(res.Data.Id);
            return View(hospital.Data);
        }

    }
}