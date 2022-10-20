

using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.IO;
using HettisentialMvc.Entities.JoinerTables;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using HettisentialMvc.MailClass;

namespace HettisentialMvc
{
    public class HEalhCenterService : IHealthCenerService
    {
          private readonly IImageRepo _imgRepo;
          private readonly IEmailService _Mail;
        private readonly IHealthCenteRRepo  _HealhCenterRepo;
       private readonly IUserRepo _UserRepo;
          private readonly IRoleRepo _RoleRepo;
          private readonly IWebHostEnvironment _Webhostenvironment;
        private readonly IAddressRepo _adderesRepo;
        ///   private readonly IEmail _mal;

        public HEalhCenterService (   IEmailService mail,  IAddressRepo address, IImageRepo img, IHealthCenteRRepo healthCenteRRepo,IUserRepo USERREPO,IRoleRepo rolerepo,IWebHostEnvironment webhost)
        {
            _HealhCenterRepo = healthCenteRRepo;
            _RoleRepo = rolerepo;
           // _Mail = mail;
           // _mal = ml;
            _imgRepo = img;
            _UserRepo = USERREPO;
            _Webhostenvironment = webhost;
            _adderesRepo = address;
             
        }

        public BaseResponseModel<HealthCenterDto> Create(CreateHealthCenterRequestModel model)
        {
        
           // var healthCenter = _HealhCenterRepo.get( x => x.   );
           var creaTe = _HealhCenterRepo.ExistByEmail(model.Email);
            if (creaTe)
            {
                return new BaseResponseModel<HealthCenterDto>
                {
                      Measage = "pharmacy already exists",
                    Status = false,
                };
            }
              var imageName = "";
           if(model.IHealthCenterImage != null)
           {
               var imPath =  _Webhostenvironment.WebRootPath;
               var imagePath = Path.Combine(imPath, "images");
               Directory.CreateDirectory(imagePath);
               var imageType= model.IHealthCenterImage.ContentType.Split('/')[1];
              
                    imageName = $"{Guid.NewGuid()}.{imageType}";
                    var fullPath = Path.Combine(imagePath, imageName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        model.IHealthCenterImage.CopyTo(fileStream);
                    }
              
              
            }
             else 
               {
                    return new BaseResponseModel<HealthCenterDto>
                    {
                        Measage = "file not supported!",
                        Status = false,
                    };
               }
            

              var user = new User
            {
                UserFirstName = model.HealthCenterName,
            
                Email = model.Email,
                
                PhoneNumber = model.PhoneNumber,

                
             
          
            };
           
            var role = _RoleRepo.GetByName("HealthCenter");
            var userRole = new UserRole
            {
                User = user,
                UserId = user.Id,
                Role = role,
                RoleId = role.Id
            };

            user.UserRoles.Add(userRole);
            var newAdmin = new HealthCenter
            {
                HealthCenterName = model.HealthCenterName,
                        Category  = model.Category,
              Email = model.Email,
              PhoneNumber= model.PhoneNumber,
              HoursOfWork = model.HoursOfWork,
              WebsiteUrl = model.WebsiteUrl,
              Description = model.Description,
            
              UserId = user.Id,
              User = user,
               

                 Country =  model.Country,
                LocalGovernmentArea = model.LocalGovernmentArea,
                City = model.City,
                PostalCode = model.PostalCode,
                StreetAddress = model.StreetAddress,
                State = model.State,
                Image= imageName,
 
                
            };

           
             var userInfo =  _UserRepo.Create(user);
            var adminInfo = _HealhCenterRepo.Create(newAdmin);

            //  var EmailDetail = new EmailDto
            // {
            //     ReceiverEmail = newAdmin.User.Email,
            //     ReceiverName = newAdmin.User.UserFirstName,
            
            //     Message = $"Welcome to Your Business Profile, {newAdmin.User.UserFirstName} ",
            //     Subject = "  Welcome to Hettisential Business Profile, a free tool that helps you turn searchers on Google into loyal Users. Your account is a one-stop shop where you can manage your Business Profile to attract new Users and engage directly with existing ones.  "
            // };
              
            // //  _Mail.SendEmail(EmailDetail);
            // _Mail.SendEmail(EmailDetail);
        
            return new BaseResponseModel<HealthCenterDto>
            {
                Measage = "HealthCenter successfully created",
                Status  = true,
                Data = adminInfo
            };
        }

        public BaseResponseModel<bool> Delete(int id)
        {
            var healthCenter = _HealhCenterRepo.get(id);
            if (healthCenter == null)
            {
                return new BaseResponseModel<bool>
                {
                    Measage = "HealthCenter not found",
                    Status = false,
                    Data = false

                };
            }
            _HealhCenterRepo.DeleTe(healthCenter);
            return new BaseResponseModel<bool>
            {
                Measage = "HealthCenter successfully Deleted",
                Status = true,
                Data = true
            };
        }

        public BaseResponseModel<List<HealthCenterDto>> GetAllHealthCenter()
        {
               var healthCenter = _HealhCenterRepo.GetAllHealthCener();
            if (healthCenter == null)
            {
                return new BaseResponseModel<List<HealthCenterDto>>
                {
                    Measage = "No HealthCenter Found",
                    Status = false
                };
            }
            return new BaseResponseModel<List<HealthCenterDto>>
            {
                Measage = "Admin successfully retrieved",
                Status = true,
                Data = healthCenter
            };
        }

        public BaseResponseModel<HealthCenterDto> GetHealthCenterById(int Id)
        {
             var phr = _HealhCenterRepo.get( Id     );
            if (phr  == null )
            {
                return new BaseResponseModel<HealthCenterDto>
                {
                    Measage = "pharmacy doesn't exist",
                    Status = false
                };
            }
            var hosp = _HealhCenterRepo.ReturnById(Id);
            return new BaseResponseModel<HealthCenterDto>
            {
                Measage = "Pharmarcy successfully retrieved",
                Status = true,
                Data = hosp
            };
        }

        public BaseResponseModel<HealthCenterDto> GetHealthCenterByLGA(string LGA)
        {
           var healthCenter =   _HealhCenterRepo. GetHealthCenterByLGA(LGA);
            if (healthCenter == null)
            {
                return new BaseResponseModel<HealthCenterDto>
                {
                    Measage = "HealthCenter Not Available", 
                    Status = false
                };
            }
            var healthCenterDto = new HealthCenterDto
            {
                 HealthCenterName = healthCenter.HealthCenterName,
                    Category = healthCenter.Category,
                    Email = healthCenter.Email,
                    PhoneNumber = healthCenter.PhoneNumber,
                    WebsiteUrl = healthCenter.WebsiteUrl,
                    Description = healthCenter.Description,
                  
                    healthCenterServices = healthCenter.healthCenterServices,
                    HoursOfWork = healthCenter.HoursOfWork,
                    Images = (ICollection<ImageDTO>)healthCenter.images,
                    UserId = (int)healthCenter.UserId,
                    IHealthCenterImage = healthCenter.Image,




                     Country =  healthCenter.Country,
                LocalGovernmentArea = healthCenter.LocalGovernmentArea,
                City = healthCenter.City,
                PostalCode = healthCenter.PostalCode,
                StreetAddress = healthCenter.StreetAddress,
                State = healthCenter.State,
            };
 
            return new BaseResponseModel<HealthCenterDto>
            {
                Data = healthCenterDto,
                Measage = "HealthCenter Pharmacy",
                Status = true
            };
        }

        public BaseResponseModel<HealthCenterDto> GetHealthCenterByState(string State)
        {
           var healthCenter =   _HealhCenterRepo. GetHealthCenterByState(State);
            if (healthCenter == null)
            {
                return new BaseResponseModel<HealthCenterDto>
                {
                    Measage = "HealthCenter Not Available", 
                    Status = false
                };
            }
            var pharmacyDTo = healthCenter.Select(pharmacy => new HealthCenterDto
            {
                Id = pharmacy.Id,
                 HealthCenterName = pharmacy.HealthCenterName,
                    Category = pharmacy.Category,
                    Email = pharmacy.Email,
                    PhoneNumber = pharmacy.PhoneNumber,
                    WebsiteUrl = pharmacy.WebsiteUrl,
                    Description = pharmacy.Description,
                  
                  
                    HoursOfWork = pharmacy.HoursOfWork,
                
                    UserId = (int)pharmacy.UserId,
                    IHealthCenterImage = pharmacy.Image,

                        Country =  pharmacy.Country,
                LocalGovernmentArea = pharmacy.LocalGovernmentArea,
                City = pharmacy.City,
                PostalCode = pharmacy.PostalCode,
                StreetAddress = pharmacy.StreetAddress,
                State = pharmacy.State,

                    
                
            }).ToList();
 
            return new BaseResponseModel<HealthCenterDto>
            {
               
                Measage = "Available HealthCenter",
                Status = true
            };
        }

        public BaseResponseModel<HealthCenterDto> ReturnById(int id)
        {
           var healtH = _HealhCenterRepo.ExistById(id);
            if(healtH == false)
            {
                return new BaseResponseModel<HealthCenterDto>
                {
                    Measage = " HealthCenter  doesn't exist",
                    Status = false
                };
            }
            var HealthCenteR = _HealhCenterRepo.ReturnById(id);
            return new BaseResponseModel<HealthCenterDto>
            {
                Measage = "HealthCenter successfully retrieved",
                Status = true,
                Data = HealthCenteR
            };  
        }

        public BaseResponseModel<IEnumerable<HealthCenterDto>> Search(string Search)
        {
           var repo  = _HealhCenterRepo.Search(Search);

           if (repo == null)
           {
              return new BaseResponseModel<IEnumerable<HealthCenterDto>>
              {
                    Measage = "Not Found",
                    Status = false,
              };

           }
           else
           {
              return new BaseResponseModel<IEnumerable<HealthCenterDto>>
              {
                    Data = repo,
              };
           }
          

        }

        // public BaseResponseModel<HealthCenterDto> Search(string Search)
        // {
        //    var  sch =  _HealhCenterRepo.Search(Search);
        //    return new BaseResponseModel<HealthCenterDto>

        //    {

        //    };

        // }

        public BaseResponseModel<HealthCenterDto> Update(UpdateHealthCenterRequestModel request, int id)
        {
                  var imageName = "";
           if(request.IHealthCenterImage != null)
           {
               var imPath= _Webhostenvironment.WebRootPath;
               var imagePath = Path.Combine(imPath, "myImages");
               Directory.CreateDirectory(imagePath);
               var imageType= request.IHealthCenterImage.ContentType.Split('/')[1];
               if(imageType=="jpeg"|| imageType=="png"||imageType=="jpg" && (request.IHealthCenterImage.Length<=2000000))
               {
                    imageName = $"{Guid.NewGuid()}.{imageType}";
                    var fullPath = Path.Combine(imagePath, imageName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        request.IHealthCenterImage.CopyTo(fileStream);
                    }
               }
               else 
               {
                    return new BaseResponseModel<HealthCenterDto>
                    {
                        Measage = "file not supported!",
                        Status = false,
                    };
               }

           }  
                var phar = _HealhCenterRepo.ExistById(id);
                if (phar != true)
                {
                  return new BaseResponseModel<HealthCenterDto>
                  {
                         Measage = "HealthCenter Does Not Exist ",
                         Status = false,
                  };

                }

                var pharmacyinfo  = _HealhCenterRepo.get(id);
                var user = _UserRepo.Get((int)pharmacyinfo.UserId);
                pharmacyinfo.HealthCenterName = request.HealthCenterName ?? pharmacyinfo.HealthCenterName;
                pharmacyinfo.PhoneNumber = request.PhoneNumber?? pharmacyinfo.PhoneNumber;
                pharmacyinfo.healthCenterServices = request.healthCenterServices?? pharmacyinfo.healthCenterServices;
                pharmacyinfo.HoursOfWork = request.HoursOfWork?? pharmacyinfo.HoursOfWork;
                pharmacyinfo.WebsiteUrl = request.WebsiteUrl?? pharmacyinfo.WebsiteUrl;
                pharmacyinfo.Category = request.Category?? pharmacyinfo.Category;
                pharmacyinfo.Description = request.Description?? pharmacyinfo.Description;
                 pharmacyinfo.Country = request.Country ?? pharmacyinfo.City;
              pharmacyinfo.City = request.City ?? pharmacyinfo.City;
             pharmacyinfo.StreetAddress = request.StreetAddress ?? pharmacyinfo.StreetAddress;
              pharmacyinfo.PostalCode = request.PostalCode ; 

                var newPharmacy = _HealhCenterRepo.Update(pharmacyinfo);
                _UserRepo.Update(user);
                return new BaseResponseModel<HealthCenterDto>
                {
                    Measage = "HealthCenter updaTed Sucessfully",
                    Status = true,
                    Data = new HealthCenterDto
                    {
                        
                        HealthCenterName = newPharmacy.HealthCenterName,
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
    }
}