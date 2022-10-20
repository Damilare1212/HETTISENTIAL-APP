

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HettisentialMvc.Entities.JoinerTables;
using HettisentialMvc.MailClass;
using Microsoft.AspNetCore.Hosting;

namespace HettisentialMvc
{
     public class  MedicalLabServices : IMedicalLabServices
     {
         private readonly IUserRepo _UserRepo;
          private readonly IRoleRepo _RoleRepo;
           private readonly IWebHostEnvironment _Webhostenvironment;

           private readonly IMedicalLabRepo _MedicalLab;

            //  private readonly IEmailService _Mail;


           public MedicalLabServices ( IEmailService Mail, IUserRepo UserRepo, IRoleRepo roleRepo, IWebHostEnvironment webhos, IMedicalLabRepo medLab )
           {
               _UserRepo= UserRepo;
               _RoleRepo = roleRepo;
               _Webhostenvironment = webhos;
               _MedicalLab = medLab;
              // _Mail = Mail;
           }

        public BaseResponseModel<MedicalLabDTo> Create(CreateMedicalLabRequestModel model)
        {
             var creaTe = _MedicalLab.ExistByEmail(model.Email);
            if (creaTe)
            {
                return new BaseResponseModel<MedicalLabDTo>
                {
                      Measage = "Medical already exists",
                    Status = false,
                };
            }
              var imageName = "";
         
           if(model.LabImage != null)
           {
               var imPath =  _Webhostenvironment.WebRootPath;
               var imagePath = Path.Combine(imPath, "images");
               Directory.CreateDirectory(imagePath);
               var imageType= model.LabImage.ContentType.Split('/')[1];
              
                    imageName = $"{Guid.NewGuid()}.{imageType}";
                    var fullPath = Path.Combine(imagePath, imageName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        model.LabImage.CopyTo(fileStream);
                    }
              
              
            }
             else 
               {
                    return new BaseResponseModel<MedicalLabDTo>
                    {
                        Measage = "file not supported!",
                        Status = false,
                    };
               }
            

              var user = new User
            {
                UserFirstName = model.LabName,
            
                Email = model.Email,
                
                PhoneNumber = model.PhoneNumber,
             
          
            };
           
            var role = _RoleRepo.GetByName("MedicalLAb");
            var userRole = new UserRole
            {
                User = user,
                UserId = user.Id,
                Role = role,
                RoleId = role.Id
            };
            user.UserRoles.Add(userRole);
            var newAdmin = new MedicalLab
            {
                LabName = model.LabName,
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
            var adminInfo = _MedicalLab.Create(newAdmin);
             //  var EmailDetail = new EmailDto
            // {
            //     ReceiverEmail = newAdmin.User.Email,
            //     ReceiverName = newAdmin.User.UserFirstName,
            
            //     Message = $"Welcome to Your Business Profile, {newAdmin.User.UserFirstName} ",
            //     Subject = "  Welcome to Hettisential Business Profile, a free tool that helps you turn searchers on Google into loyal Users. Your account is a one-stop shop where you can manage your Business Profile to attract new Users and engage directly with existing ones.  "
            // };
              
            //   _Mail.SendEmail(EmailDetail);
            
          
            return new BaseResponseModel<MedicalLabDTo>
            {
                Measage = "Admin successfully created",
                Status  = true,
                Data = adminInfo
            };
 
        }

        public BaseResponseModel<bool> Delete(int id)
        {
              var admin = _MedicalLab.get(id);
            if (admin == null)
            {
                return new BaseResponseModel<bool>
                {
                    Measage = "MedicalLab not found",
                    Status = false,
                    Data = false

                };
            }
            _MedicalLab.DeleTe(admin);
            return new BaseResponseModel<bool>
            {
                Measage = "MedicalLab successfully Deleted",
                Status = true,
                Data = true
            };
        }

        public BaseResponseModel<List<MedicalLabDTo>> GetAllMedicalLab()
        {
                var admins = _MedicalLab.GetAllMedicalLab();
            if (admins == null)
            {
                return new BaseResponseModel<List<MedicalLabDTo>>
                {
                    Measage = "No MedicalLab Found",
                    Status = false
                };
            }
            return new BaseResponseModel<List<MedicalLabDTo>>
            {
                Measage = "MedicalLab successfully retrieved",
                Status = true,
                Data = admins
            };
        }

        public BaseResponseModel<MedicalLabDTo> GetMedicalByLGA(string LGA)
        {
             var pharmacy =   _MedicalLab. GetMedicalLabByLGA(LGA);
            if (pharmacy == null)
            {
                return new BaseResponseModel<MedicalLabDTo>
                {
                    Measage = "medicalLab Not Available", 
                    Status = false
                };
            }
            var PharmacyDTo = new MedicalLabDTo
            {
                 LabName = pharmacy.LabName,
                    Category = pharmacy.Category,
                    Email = pharmacy.Email,
                    PhoneNumber = pharmacy.PhoneNumber,
                    WebsiteUrl = pharmacy.WebsiteUrl,
                    Description = pharmacy.Description,
                  
                    HoursOfWork = pharmacy.HoursOfWork,
                   // Images = (ICollection<ImageDTO>)pharmacy.images,
                    UserId = (int)pharmacy.UserId,
                    LabImage = pharmacy.Image,




                     Country =  pharmacy.Country,
                LocalGovernmentArea = pharmacy.LocalGovernmentArea,
                City = pharmacy.City,
                PostalCode = pharmacy.PostalCode,
                StreetAddress = pharmacy.StreetAddress,
                State = pharmacy.State,
            };
 
            return new BaseResponseModel<MedicalLabDTo>
            {
                Data = PharmacyDTo,
                Measage = "Available Pharmacy",
                Status = true
            };
        }

        public BaseResponseModel<MedicalLabDTo> GetMedicalByState(string State)
        {
            var pharmacy = _MedicalLab.GetMedicalLabByState(State);
              if (pharmacy == null)
            {
                return new BaseResponseModel<MedicalLabDTo>
                {
                    Measage = "Pharmacy Not Available", 
                    Status = false
                };
            }
            var pharmacyDTo = pharmacy.Select(pharmacy => new MedicalLabDTo
            {
                Id = pharmacy.Id,
                 LabName = pharmacy.LabName,
                    Category = pharmacy.Category,
                    Email = pharmacy.Email,
                    PhoneNumber = pharmacy.PhoneNumber,
                    WebsiteUrl = pharmacy.WebsiteUrl,
                    Description = pharmacy.Description,
                  
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
 
            return new BaseResponseModel<MedicalLabDTo>
            {
             
                Measage = "Available Pharmacy",
                Status = true
            };
        }

        public BaseResponseModel<MedicalLabDTo> GetMedicalLabById(int Id)
        {
            var phr = _MedicalLab.get( Id     );
            if (phr  == null )
            {
                return new BaseResponseModel<MedicalLabDTo>
                {
                    Measage = "pharmacy doesn't exist",
                    Status = false
                };
            }
            var hosp = _MedicalLab.ReturnById(Id);
            return new BaseResponseModel<MedicalLabDTo>
            {
                Measage = "Pharmarcy successfully retrieved",
                Status = true,
                Data = hosp
            };
        }

        public BaseResponseModel<MedicalLabDTo> ReturnById(int id)
        {
           var pharmarcy = _MedicalLab.ExistById(id);
            if(pharmarcy == false)
            {
                return new BaseResponseModel<MedicalLabDTo>
                {
                    Measage = " pharmarcy doesn't exist",
                    Status = false
                };
            }
            var Npharmarcy = _MedicalLab.ReturnById(id);
            return new BaseResponseModel<MedicalLabDTo>
            {
                Measage = "pharmarcy successfully retrieved",
                Status = true,
                Data = Npharmarcy
            };  
        }

        public BaseResponseModel<MedicalLabDTo> Update(UpdateMedicalLabRequestModel request, int id)
        {
              var imageName = "";
           if(request.LabImage != null)
           {
               var imPath= _Webhostenvironment.WebRootPath;
               var imagePath = Path.Combine(imPath, "images");
               Directory.CreateDirectory(imagePath);
               var imageType= request.LabImage.ContentType.Split('/')[1];
               if(imageType=="jpeg"|| imageType=="png"||imageType=="jpg" && (request.LabImage.Length<=2000000))
               {
                    imageName = $"{Guid.NewGuid()}.{imageType}";
                    var fullPath = Path.Combine(imagePath, imageName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        request.LabImage.CopyTo(fileStream);
                    }
               }
               else 
               {
                    return new BaseResponseModel<MedicalLabDTo>
                    {
                        Measage = "file not supported!",
                        Status = false,
                    };
               }

           }  
                var phar = _MedicalLab.ExistById(id);
                if (phar != true)
                {
                  return new BaseResponseModel<MedicalLabDTo>
                  {
                         Measage = "Pharmarcy Does Not Exist ",
                         Status = false,
                  };

                }

                var pharmacyinfo  = _MedicalLab.get(id);
                var user = _UserRepo.Get((int)pharmacyinfo.UserId);
                pharmacyinfo.LabName = request.LabName ?? pharmacyinfo.LabName;
                pharmacyinfo.PhoneNumber = request.PhoneNumber?? pharmacyinfo.PhoneNumber;
               /// pharmacyinfo.pharmacyServices = request.pharmacyServices?? pharmacyinfo.pharmacyServices;
                pharmacyinfo.HoursOfWork = request.HoursOfWork?? pharmacyinfo.HoursOfWork;
                pharmacyinfo.WebsiteUrl = request.WebsiteUrl?? pharmacyinfo.WebsiteUrl;
                pharmacyinfo.Category = request.Category?? pharmacyinfo.Category;
                pharmacyinfo.Description = request.Description?? pharmacyinfo.Description;
                 pharmacyinfo.Country = request.Country ?? pharmacyinfo.City;
              pharmacyinfo.City = request.City ?? pharmacyinfo.City;
             pharmacyinfo.StreetAddress = request.StreetAddress ?? pharmacyinfo.StreetAddress;
              pharmacyinfo.PostalCode = request.PostalCode ; 

                var newPharmacy = _MedicalLab.Update(pharmacyinfo);
                _UserRepo.Update(user);
                return new BaseResponseModel<MedicalLabDTo>
                {
                    Measage = "Pharmarcy updaTed Sucessfully",
                    Status = true,
                    Data = new MedicalLabDTo
                    {
                        
                        LabName = newPharmacy.LabName,
                        Category = newPharmacy.Category,
                        Email =newPharmacy.Email,
                        PhoneNumber =newPharmacy.PhoneNumber,
                        HoursOfWork = newPharmacy.HoursOfWork,
                        WebsiteUrl = newPharmacy.WebsiteUrl,
                        Description = newPharmacy.Description,
                        UserId = (int)newPharmacy.UserId,
                      


                          Country =  newPharmacy.Country,
                LocalGovernmentArea = newPharmacy.LocalGovernmentArea,
                City = newPharmacy.City,
                PostalCode = newPharmacy.PostalCode,
                StreetAddress = newPharmacy.StreetAddress,
                State = newPharmacy.State,
                        
                    }
                };

        }
    }
}