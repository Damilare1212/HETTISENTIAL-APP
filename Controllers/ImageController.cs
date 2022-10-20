
using System.Reflection.Metadata.Ecma335;
using System;
using Microsoft.AspNetCore.Mvc;
using HettisentialMvc;

public class ImageControler : Controller{
   private readonly IMageService _ImageService;
   public ImageControler (IMageService IMGService)
   {
       _ImageService = IMGService;
   }


   
       [HttpGet]
     public IActionResult Upload()
        {
            return View();
        }


        // [HttpPost]
        // public IActionResult Upload(Image img)
        // {
        //     _ImageService.UploadImage(img);

        // }
}