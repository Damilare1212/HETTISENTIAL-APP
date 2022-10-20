

using System.Linq;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HettisentialMvc
{

    public class MedicalLabController : Controller
    {
        private readonly IMedicalLabServices _MedLAb;
        private readonly ApplicationContext _Context;

        public MedicalLabController( ApplicationContext Context, IMedicalLabServices medicalLab)
        {
            _MedLAb = medicalLab;
            _Context = Context;
        }


         [HttpGet]
           public  async Task< IActionResult> Search(string text)
           {
                 ViewData["MySearch"] = text;
                var query = from s in _Context.medicalLabs
                   
                        select s ;
                 if (!string.IsNullOrEmpty(text))
                 {
                    query = query.Where(x => x.LabName.Contains(text) || x.Country.Contains(text) || x.Email.Contains(text) || x.Category.Contains(text) );
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
           public IActionResult Create (CreateMedicalLabRequestModel model)
           {
              
               _MedLAb.Create(model);
               ViewBag.Measage = " You Have Successfuly Created An Account For Your Laboratory ";
             
                // return RedirectToAction("Login", "User" );
                 return RedirectToAction("Index", "Home" );
           }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var updaTe = _MedLAb.ReturnById(id);
            if (updaTe == null)
            {
                return NotFound();
            }
            return View();
        }
        

         [HttpPost]
        public IActionResult Update (UpdateMedicalLabRequestModel model, int id)
        {
            _MedLAb.Update(model, id);


            return RedirectToAction("GetAll");

        }

          [HttpGet]        
        public IActionResult Delete(int id)
        {

            var patient = _MedLAb.ReturnById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient.Data);
        }
        

       [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _MedLAb.Delete(id);
            return RedirectToAction("GetAll");
        }


          [HttpGet]
         public IActionResult Details(int id)
        {
            var ph = _MedLAb.ReturnById(id);
            return View(ph.Data);
        }

         [HttpGet]
        public IActionResult GetAll()
        {
            var admin = _MedLAb.GetAllMedicalLab();
            return View(admin.Data);
        }


    }
}
