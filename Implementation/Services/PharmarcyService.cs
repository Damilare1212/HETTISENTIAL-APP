
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HettisentialMvc.Entities.JoinerTables;
using HettisentialMvc.MailClass;
using Microsoft.AspNetCore.Hosting;

namespace HettisentialMvc
{
    public class PharmacyServicee : IPharmacyService
    {
            private readonly IImageRepo _imgRepo;
        private readonly IPharmacyRepo _pharmacyRepo;
       private readonly IUserRepo _UserRepo;
          private readonly IRoleRepo _RoleRepo;
          
          private readonly IWebHostEnvironment _Webhostenvironment;
         //   private readonly IEmailService _Mail;
        private readonly IAddressRepo _adderesRepo;

        public PharmacyServicee ( IEmailService Mail,  IAddressRepo address, IImageRepo img, IPharmacyRepo pharmacyRepo,IUserRepo USERREPO,IRoleRepo rolerepo,IWebHostEnvironment webhost)
        {
            _pharmacyRepo = pharmacyRepo;
            _RoleRepo = rolerepo;
            _imgRepo = img;
            _UserRepo = USERREPO;
            _Webhostenvironment = webhost;
            _adderesRepo = address;
          //  _Mail = Mail;
             
        }
        public BaseResponseModel<bool> Delete(int id)
        {
             var admin = _pharmacyRepo.get(id);
            if (admin == null)
            {
                return new BaseResponseModel<bool>
                {
                    Measage = "Pharmacy not found",
                    Status = false,
                    Data = false

                };
            }
            _pharmacyRepo.DeleTe(admin);
            return new BaseResponseModel<bool>
            {
                Measage = "Pharmacy successfully Deleted",
                Status = true,
                Data = true
            };
        }

        public BaseResponseModel<List<PharmacyDTo>> GetAllPharmacy()
        {
             var admins = _pharmacyRepo.GetAllPharmacy();
            if (admins == null)
            {
                return new BaseResponseModel<List<PharmacyDTo>>
                {
                    Measage = "No pharmacy Found",
                    Status = false
                };
            }
            return new BaseResponseModel<List<PharmacyDTo>>
            {
                Measage = "pharmacy successfully retrieved",
                Status = true,
                Data = admins
            };
        }

        public BaseResponseModel<PharmacyDTo> GetPharmacyByLGA(string LGA)
        {
              var pharmacy =   _pharmacyRepo. GetPharmacyByLGA(LGA);
            if (pharmacy == null)
            {
                return new BaseResponseModel<PharmacyDTo>
                {
                    Measage = "Pharmacy Not Available", 
                    Status = false
                };
            }
            var PharmacyDTo = new PharmacyDTo
            {
                 PharmacyName = pharmacy.PharmacyName,
                    Category = pharmacy.Category,
                    Email = pharmacy.Email,
                    PhoneNumber = pharmacy.PhoneNumber,
                    WebsiteUrl = pharmacy.WebsiteUrl,
                    Description = pharmacy.Description,
                  //  address = pharmacy.address,
                    pharmacyServices = pharmacy.pharmacyServices,
                    HoursOfWork = pharmacy.HoursOfWork,
                    Images = (ICollection<ImageDTO>)pharmacy.images,
                    UserId = (int)pharmacy.UserId,




                     Country =  pharmacy.Country,
                LocalGovernmentArea = pharmacy.LocalGovernmentArea,
                City = pharmacy.City,
                PostalCode = pharmacy.PostalCode,
                StreetAddress = pharmacy.StreetAddress,
                State = pharmacy.State,
            };
 
            return new BaseResponseModel<PharmacyDTo>
            {
                Data = PharmacyDTo,
                Measage = "Available Pharmacy",
                Status = true
            };
        }

        public BaseResponseModel<PharmacyDTo> GetPharmacyByState(string State)
        {
           var pharmacy =   _pharmacyRepo. GetPharmacyByState(State);
            if (pharmacy == null)
            {
                return new BaseResponseModel<PharmacyDTo>
                {
                    Measage = "Pharmacy Not Available", 
                    Status = false
                };
            }
            var pharmacyDTo = pharmacy.Select(pharmacy => new PharmacyDTo
            {
                Id = pharmacy.Id,
                 PharmacyName = pharmacy.PharmacyName,
                    Category = pharmacy.Category,
                    Email = pharmacy.Email,
                    PhoneNumber = pharmacy.PhoneNumber,
                    WebsiteUrl = pharmacy.WebsiteUrl,
                    Description = pharmacy.Description,
                  //  address = pharmacy.address,
                    pharmacyServices = pharmacy.pharmacyServices,
                    HoursOfWork = pharmacy.HoursOfWork,
                    Images = (ICollection<ImageDTO>)pharmacy.images,
                    UserId = (int)pharmacy.UserId,

                        Country =  pharmacy.Country,
                LocalGovernmentArea = pharmacy.LocalGovernmentArea,
                City = pharmacy.City,
                PostalCode = pharmacy.PostalCode,
                StreetAddress = pharmacy.StreetAddress,
                State = pharmacy.State,

                    
                
            }).ToList();
 
            return new BaseResponseModel<PharmacyDTo>
            {
              //  Data =  pharmacyDTo,
                Measage = "Available Pharmacy",
                Status = true
            };
        }

        public BaseResponseModel<PharmacyDTo> GetPharmacyById(int Id)
        {
            var phr = _pharmacyRepo.get( Id     );
            if (phr  == null )
            {
                return new BaseResponseModel<PharmacyDTo>
                {
                    Measage = "pharmacy doesn't exist",
                    Status = false
                };
            }
            var hosp = _pharmacyRepo.ReturnById(Id);
            return new BaseResponseModel<PharmacyDTo>
            {
                Measage = "Pharmarcy successfully retrieved",
                Status = true,
                Data = hosp
            };
        }

        //     public BaseResponseModel<PharmacyDTo> Register(CreatePharmacyRequestsmodel request)
        //     {
        //         var reg = _pharmacyRepo.ExistByEmail(request.Email); 
        //             if (reg)
        //             {
        //                 return new BaseResponseModel<PharmacyDTo>
        //                 {
        //                     Measage = "  Pharmacy   Already Exist ",
        //                     Status = false,
        //                 };
        //             }
        //           var img = "";
        //        if (request.PharmacyImage != null)
        //        {
        //            var path = _Webhostenvironment.WebRootPath;
        //            var imagepath = Path.Combine(path, "Images");
        //            Directory.CreateDirectory(imagepath);
        //            var imagetype = request.PharmacyImage.ContentType.Split('/')[1];
        //            img = $"{Guid.NewGuid()}.{imagetype}";
        //            var fullpath = Path.Combine(imagepath, img);
        //            using (var stream = new FileStream(fullpath, FileMode.Create))
        //            {
        //                 request.PharmacyImage.CopyTo(stream);
        //            }
        //        }
                

        //         var user = new User
        //         {
        //              UserFirstName = request.PharmacyName,
                
        //             Email = request.Email,
                    
        //             PhoneNumber = request.PhoneNumber,
                    
        //         };
            
        //        var role = _RoleRepo.GetByName("   Admin   ");
                
        //       var userRole = new UserRole
        //         {
        //             User = user,
        //             UserId = user.Id,
        //             Role = role,
        //             RoleId = role.Id,

        //         };
        //        user.UserRoles.Add(userRole);

        //         var add = new Address
        //         {
        //             Country =  request.Country,
        //             LocalGovernmentArea = request.LocalGovernmentArea,
        //             City = request.City,
        //             PostalCode = request.PostalCode,
        //             StreetAddress = request.StreetAddress,
        //             State = request.State,
                    
        //         };

        //         _adderesRepo.Create(add);
        //         var pharmacy = new Pharmacy
        //         {
                    
                
        //              PharmacyName = request.PharmacyName,
        //                     Category  = request.Category,
        //           Email = request.Email,
        //           PhoneNumber= request.PhoneNumber,
        //           HoursOfWork = request.HoursOfWork,
        //           WebsiteUrl = request.WebsiteUrl,
        //           Description = request.Description,
                
        //           UserId = user.Id,
        //           User = user,
                

        //         };
                
        //             var us =   _UserRepo.Create(  user  );
        //           var creaTe = _pharmacyRepo.Create(pharmacy);
        //         //      foreach (var imG in request.Images)
        //         // {
        //         //            var ig = new Image
        //         //            {
                            
        //         //                 ImagePath = imG,
        //         //                 PharmacyID = pharmacy.Id,
        //         //                 Description = request.Description,
                                

        //         //             };
        //         //           _imgRepo.Create(ig);
        //      // }
        //      return new BaseResponseModel<PharmacyDTo>
        //     {
        //         Measage = "Pharmacy Created Sucessfully ",
        //         Status =true,
        //         Data =  creaTe

        //     };
        // }

        public BaseResponseModel<PharmacyDTo> Update(UpdatePharmacyRequestsmodel request, int id)
        {
                      var imageName = "";
           if(request.PharmacyImage != null)
           {
               var imPath= _Webhostenvironment.WebRootPath;
               var imagePath = Path.Combine(imPath, "myImages");
               Directory.CreateDirectory(imagePath);
               var imageType= request.PharmacyImage.ContentType.Split('/')[1];
               if(imageType=="jpeg"|| imageType=="png"||imageType=="jpg" && (request.PharmacyImage.Length<=2000000))
               {
                    imageName = $"{Guid.NewGuid()}.{imageType}";
                    var fullPath = Path.Combine(imagePath, imageName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        request.PharmacyImage.CopyTo(fileStream);
                    }
               }
               else 
               {
                    return new BaseResponseModel<PharmacyDTo>
                    {
                        Measage = "file not supported!",
                        Status = false,
                    };
               }

           }  
                var phar = _pharmacyRepo.ExistById(id);
                if (phar != true)
                {
                  return new BaseResponseModel<PharmacyDTo>
                  {
                         Measage = "Pharmarcy Does Not Exist ",
                         Status = false,
                  };

                }

                var pharmacyinfo  = _pharmacyRepo.get(id);
                var user = _UserRepo.Get((int)pharmacyinfo.UserId);
                pharmacyinfo.PharmacyName = request.PharmacyName ?? pharmacyinfo.PharmacyName;
                pharmacyinfo.PhoneNumber = request.PhoneNumber?? pharmacyinfo.PhoneNumber;
                pharmacyinfo.pharmacyServices = request.pharmacyServices?? pharmacyinfo.pharmacyServices;
                pharmacyinfo.HoursOfWork = request.HoursOfWork?? pharmacyinfo.HoursOfWork;
                pharmacyinfo.WebsiteUrl = request.WebsiteUrl?? pharmacyinfo.WebsiteUrl;
                pharmacyinfo.Category = request.Category?? pharmacyinfo.Category;
                pharmacyinfo.Description = request.Description?? pharmacyinfo.Description;
                 pharmacyinfo.Country = request.Country ?? pharmacyinfo.City;
              pharmacyinfo.City = request.City ?? pharmacyinfo.City;
             pharmacyinfo.StreetAddress = request.StreetAddress ?? pharmacyinfo.StreetAddress;
              pharmacyinfo.PostalCode = request.PostalCode ; 

                var newPharmacy = _pharmacyRepo.Update(pharmacyinfo);
                _UserRepo.Update(user);
                return new BaseResponseModel<PharmacyDTo>
                {
                    Measage = "Pharmarcy updaTed Sucessfully",
                    Status = true,
                    Data = new PharmacyDTo
                    {
                        
                        PharmacyName = newPharmacy.PharmacyName,
                        Category = newPharmacy.Category,
                        Email =newPharmacy.Email,
                        PhoneNumber =newPharmacy.PhoneNumber,
                        HoursOfWork = newPharmacy.HoursOfWork,
                        WebsiteUrl = newPharmacy.WebsiteUrl,
                        Description = newPharmacy.Description,
                        UserId = (int)newPharmacy.UserId,
                      //  address = newPharmacy.address,


                          Country =  newPharmacy.Country,
                LocalGovernmentArea = newPharmacy.LocalGovernmentArea,
                City = newPharmacy.City,
                PostalCode = newPharmacy.PostalCode,
                StreetAddress = newPharmacy.StreetAddress,
                State = newPharmacy.State,
                        
                    }
                };

        }

        public BaseResponseModel<PharmacyDTo> ReturnById(int id)
        {
             var pharmarcy = _pharmacyRepo.ExistById(id);
            if(pharmarcy == false)
            {
                return new BaseResponseModel<PharmacyDTo>
                {
                    Measage = " pharmarcy doesn't exist",
                    Status = false
                };
            }
            var Npharmarcy = _pharmacyRepo.ReturnById(id);
            return new BaseResponseModel<PharmacyDTo>
            {
                Measage = "pharmarcy successfully retrieved",
                Status = true,
                Data = Npharmarcy
            };  
        }

        public BaseResponseModel<PharmacyDTo> Create(CreatePharmacyRequestsmodel model)
        {
             var creaTe = _pharmacyRepo.ExistByEmail(model.Email);
            if (creaTe)
            {
                return new BaseResponseModel<PharmacyDTo>
                {
                      Measage = "pharmacy already exists",
                    Status = false,
                };
            }

              var imageName = "";
          
           if(model.PharmacyImage != null)
           {
               var imPath =  _Webhostenvironment.WebRootPath;
               var imagePath = Path.Combine(imPath, "images");
               Directory.CreateDirectory(imagePath);
               var imageType= model.PharmacyImage.ContentType.Split('/')[1];
              
                    imageName = $"{Guid.NewGuid()}.{imageType}";
                    var fullPath = Path.Combine(imagePath, imageName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        model.PharmacyImage.CopyTo(fileStream);
                    }
              
              
            }
             else 
               {
                    return new BaseResponseModel<PharmacyDTo>
                    {
                        Measage = "file not supported!",
                        Status = false,
                    };
               }
            

              var user = new User
            {
                UserFirstName = model.PharmacyName,
            
                Email = model.Email,
                
                PhoneNumber = model.PhoneNumber,
             
          
            };
           
            var role = _RoleRepo.GetByName("Pharmacy");
            var userRole = new UserRole
            {
                User = user,
                UserId = user.Id,
                Role = role,
                RoleId = role.Id
            };
            user.UserRoles.Add(userRole);
            var newAdmin = new Pharmacy
            {
                PharmacyName = model.PharmacyName,
                        Category  = model.Category,
              Email = model.Email,
              PhoneNumber= model.PhoneNumber,
              HoursOfWork = model.HoursOfWork,
              WebsiteUrl = model.WebsiteUrl,
              Description = model.Description,
              
              UserId = user.Id,
              User = user,
               
                  Image = imageName,
                 Country =  model.Country,
                LocalGovernmentArea = model.LocalGovernmentArea,
                City = model.City,
                PostalCode = model.PostalCode,
                StreetAddress = model.StreetAddress,
                State = model.State,
 
                
            };
          
             var userInfo =  _UserRepo.Create(user);
            var adminInfo = _pharmacyRepo.Create(newAdmin);
              //   var EmailDetail = new EmailDto
            // {
            //     ReceiverEmail = newAdmin.User.Email,
            //     ReceiverName = newAdmin.User.UserFirstName,
            
            //     Message = $"Welcome to Your Business Profile, {newAdmin.User.UserFirstName} ",
            //     Subject = "  Welcome to Hettisential Business Profile, a free tool that helps you turn searchers on Google into loyal Users. Your account is a one-stop shop where you can manage your Business Profile to attract new Users and engage directly with existing ones.  "
            // };
              
            //   _Mail.SendEmail(EmailDetail);
           
            return new BaseResponseModel<PharmacyDTo>
            {
                Measage = "Admin successfully created",
                Status  = true,
                Data = adminInfo
            };
 
        }
    }

}