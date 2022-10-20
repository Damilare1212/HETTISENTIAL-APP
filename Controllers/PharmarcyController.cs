

using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HettisentialMvc
{

    public class PharmarcyController : Controller
    {
        private readonly IPharmacyService _PharmarcyService;
        private readonly ApplicationContext _Context;
        public PharmarcyController(ApplicationContext Context, IPharmacyService phar)
        {
            _PharmarcyService = phar;
            _Context = Context;
        }
         

          [HttpGet]
           public  async Task< IActionResult> Search(string text)
           {
                 ViewData["MySearch"] = text;
                var query = from s in _Context.pharmacies
                    //    where EF.Functions.Like(s.HealthCenterName,   $"%{text}%"  )
                        select s ;
                 if (!string.IsNullOrEmpty(text))
                 {
                    query = query.Where(x => x.PharmacyName.Contains(text) || x.Country.Contains(text) || x.Email.Contains(text) || x.Category.Contains(text) );
                 }

                 return View (await query.AsNoTracking().ToListAsync());
                       
                         

           }
         
        [HttpGet]
         public IActionResult Index ()
         {
            return View();
         }

        
        [HttpGet]
         public IActionResult Create   ()
         {
            return View();
         }


        [HttpPost]
           public IActionResult Create (CreatePharmacyRequestsmodel model)
           {
              
               _PharmarcyService.Create(model);
               ViewBag.Measage = " You Have Successfuly Created An Account For Your Pharmacy ";
              // return RedirectToAction     (   "Create",    "Address"     );
                // return RedirectToAction("Login", "User" );
                 return RedirectToAction("Index", "Home" );
           }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var updaTe = _PharmarcyService.ReturnById(id);
            if (updaTe == null)
            {
                return NotFound();
            }
            return View();
        }
        

         [HttpPost]
        public IActionResult Update (UpdatePharmacyRequestsmodel model, int id)
        {
            _PharmarcyService.Update(model, id);


            return RedirectToAction("GetAll");

        }

          [HttpGet]        
        public IActionResult Delete(int id)
        {

            var patient = _PharmarcyService.ReturnById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient.Data);
        }
        

       [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _PharmarcyService.Delete(id);
            return RedirectToAction("GetAll");
        }


          [HttpGet]
         public IActionResult Details(int id)
        {
            var ph = _PharmarcyService.ReturnById(id);
            return View(ph.Data);
        }

         [HttpGet]
        public IActionResult GetAll()
        {
            var admin = _PharmarcyService.GetAllPharmacy();
            return View(admin.Data);
        }


    }
}
