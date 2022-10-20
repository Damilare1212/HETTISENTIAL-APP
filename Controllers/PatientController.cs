using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HettisentialMvc
{
    public class PatientController : Controller
    {
        private readonly IApplicationUSerService _patientService;

        public PatientController(IApplicationUSerService paTienT)
        {
            _patientService = paTienT;
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
        public IActionResult Create(CreatePatientRequestModel model)
        {
            _patientService.Create(model);
             TempData["CreationPatient"] = "Registration successfull";
            return RedirectToAction("LogIn", "User");
        }

          [HttpGet]
        public IActionResult Update(int id)
        {
            var updaTe = _patientService.ReturnById(id);
            if (updaTe == null)
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Update (UpdatePatientRequestModel model, int id)
        {
            _patientService.Update(model, id);


            return RedirectToAction("GetAll");

        }

          [HttpGet]        
        public IActionResult Delete(int id)
        {

            var patient = _patientService.ReturnById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient.Data);
        }
        
       // [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _patientService.Delete(id);
            return RedirectToAction("GetAll");
        }


        //[Authorize(Roles= "Admin")]
        [HttpGet]
        public IActionResult Details(int id)
        {
            var patient = _patientService.ReturnById(id);
            return View(patient.Data);
        }

        //  [Authorize(Roles="Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var patients = _patientService.GetAll();
            return View(patients.Data);
        }
        [HttpGet]
        public IActionResult Profile()
        {
            var rest = User.FindFirst(ClaimTypes.Email).Value;
            var res = _patientService.GetByEmail(rest);
            var pats = _patientService.ReturnById(res.Data.Id);
            return View(pats.Data);
        }
    }
}