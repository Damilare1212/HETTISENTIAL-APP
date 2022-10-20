

using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Linq;
using HettisentialMvc.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Threading.Tasks;

namespace HettisentialMvc
{
    public class HealthcenterController : Controller
    {

        private readonly IHealthCenerService _healhCenterService;
        private readonly ApplicationContext _Conext;
        //  private  readonly ITempDataDictionary _tempDataDictionary;
        //  private readonly ITempDataDictionaryFactory  _Factory;

        
        public HealthcenterController(  IHealthCenerService healhCenterService, ApplicationContext conext    /*ITempDataDictionaryFactory fac  , ITempDataDictionary tempDataDictionary*/ )
        {
            _healhCenterService = healhCenterService;
            _Conext = conext;
            //  _tempDataDictionary = tempDataDictionary;
            //  _Factory = fac;
        }

          
           [HttpGet]
           public  async Task< IActionResult> Search(string text)
           {
                 ViewData["MySearch"] = text;
                var query = from s in _Conext.healthCenters
                
                        select s ;
                    
                 if (!string.IsNullOrEmpty(text))
                 {
                    query = query.Where(x => x.HealthCenterName.Contains(text) || x.Country.Contains(text) || x.Email.Contains(text) || x.Category.Contains(text) );
                     //  query = query.Where(x => !x.HealthCenterName.Contains(text) || !x.Country.Contains(text) || !x.Email.Contains(text) );

                    // TempData["Message"] =  "No Records Match This Search Request";
                     
                 }
                 
                 else  if (!string.IsNullOrEmpty(text))
                 {
                       
                        query = query.Where(x => x.HealthCenterName.Contains(text) || x.Country.Contains(text) || x.Email.Contains(text) );
                         // TempData["Message"] =  "No Records Match This Search Request";
                     
                 }

                 
                   //   TempData["Message"] =  "No Records Match This Search Request";
                 
                    
                
               
                        return View (await query.AsNoTracking().ToListAsync());
                
            
              
           }

      
       
 
 


          public IActionResult Error()
           {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id 
                ?? HttpContext.TraceIdentifier });

           }
        

         
        
            
        // [HttpGet]
        // public IActionResult SearchHealthCentres(   )
        // {
        //     return View();
        // }

    

      //  [HttpPost]
        // public IActionResult SearchHealthCentres (string text)
        // {
            // var temp = TDC;
           // var TempData  = _Factory.GetTempData((Microsoft.AspNetCore.Http.HttpContext)_tempDataDictionary );
          
         
            
            //  var searchResults = _healhCenterService.Search(text);
            //  TempData["Searches"] = searchResults ;







           //  TempDataExtension.Put<IEnumerable<HealthCenterDto>>(_tempDataDictionary,"searchResults",searchResults.Data.ToList());
        //     return RedirectToAction("SearchResultsDisplay");
        // }

        [HttpGet]
        // public IActionResult SearchResultsDisplay()
        // {
           //var searchResults = TempDataExtension.Get<IEnumerable<HealthCenterDto>>(_tempDataDictionary,"searchResults");
          //  return View(searchResults);
        //       var  searchResults =  ViewData["searchResults"] as List<HealthCenterDto>;
               
        //    return View(  ViewData["Searchess"] =  searchResults  );
           
           

       // }

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
        public IActionResult Create(CreateHealthCenterRequestModel model)
        {
            _healhCenterService.Create(model);
            ViewBag.Measage = " You Have Successfully Created An Account For Your HEalthCenter ";
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var updaTe = _healhCenterService.ReturnById(id);
            if (updaTe == null)
            {
                return NotFound();
            }
            return View();
        }


        [HttpPost]
        public IActionResult Update(UpdateHealthCenterRequestModel model, int id)
        {
            _healhCenterService.Update(model, id);


            return RedirectToAction("GetAll");

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            var patient = _healhCenterService.ReturnById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient.Data);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _healhCenterService.Delete(id);
            return RedirectToAction("GetAll");
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            var ph = _healhCenterService.ReturnById(id);
            return View(ph.Data);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var admin = _healhCenterService.GetAllHealthCenter();
            return View(admin.Data);
            
        }

     

    }
}