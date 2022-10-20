using System.Net.Mime;
using System.Net.Cache;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using HettisentialMvc.Entities.JoinerTables;
using System.Linq;
using HettisentialMvc.MailClass;

namespace HettisentialMvc{
   public class HealthService : IHealthCenterService
    {
        private readonly IUserRepo _Userrepo;
        
       //  private readonly IEmailService _Mail;
		private readonly IRoleRepo _Rolerepo;
		private readonly IHospitAlRepo _Hospital;
		private readonly IWebHostEnvironment _webhost;


        

		public HealthService (IEmailService mail,  IRoleRepo rolerepo, IUserRepo userrepo, IHospitAlRepo HealthCenterRepo,IWebHostEnvironment webhost)
		{
			_Hospital = HealthCenterRepo;
			_webhost = webhost;
			_Rolerepo = rolerepo;
			_Userrepo = userrepo;
           // _Mail = mail;
		}

        

       
        public BaseResponseModel<List<HospitalDto>> GetAllHospital()
        {
            var hos = _Hospital.GetAllHospital();
            if(hos == null)
            {
                return new BaseResponseModel<List< HospitalDto>>
                {
                    Measage = "No hospital Found",
                    Status = false
                };
            }
            return new BaseResponseModel<List<HospitalDto>>
            {
                Measage = "  hospital successfully retrieved",
                Status = true,
                Data =  hos,
                //   Id = geT.Id,
                //     HealthCenterName = geT.Name,
                //     HealthCenterImage = geT.HospitalImage,
                //     HealthCenterPhoneNumber  = geT.PhoneNumber,
                //     HealthCenterAddress = geT.Address,
                //     HealthCenterCategory = geT.HealthCenterCategory,
                //     HEalthCenterEmail = geT.Email,
                    

            };
        }

        public BaseResponseModel<HospitalDto> GetByMail(string Email)
        {
            var mail = _Hospital.GetByMail(Email);
            if (mail == null)
            {
                return new BaseResponseModel<HospitalDto>
                {
                    Measage = "No Hospital Found",
                    Status = false,
                };
            }
            return new BaseResponseModel<HospitalDto>
            {
                  Measage = " Hospital Found",
                    Status = false,
                    Data = new HospitalDto

                    {
                        Id = mail.Id,
                        HealthCenterName = mail.Name,
                      //  HealthCenterAddress = mail.Address,

                    }
            };
        }

        

        public BaseResponseModel<HospitalDto> GetHospital(int Id)
        {
           var geT = _Hospital.Get(Id);
            if (geT == null)
            {
                return new BaseResponseModel<HospitalDto>
                {
                    Measage = "HealthCener NotFound ",
                    Status = false,
                };
            }
            return new BaseResponseModel<HospitalDto>
            {
                Status = true,
                Data = new HospitalDto
                {
                    Id = geT.Id,
                    HealthCenterName = geT.Name,
                    HealthCenterImage = geT.HospitalImage,
                    HealthCenterPhoneNumber  = geT.PhoneNumber,
                  //  HealthCenterAddress = geT.Address,
                    HealthCenterCategory = geT.HealthCenterCategory,
                    HEalthCenterEmail = geT.Email,
                    
                }
            };
        }

        public BaseResponseModel<HospitalDto> GetHospitalByCategory(HospitalCategory Category)
        {
           var caegory = _Hospital.GetHospitalByCategory(Category);
            if (caegory == null)
            {
                return new BaseResponseModel<HospitalDto>
                {
                    Measage = $" {Category} not  found",
			    	Status = false,
                };
            }
            return new BaseResponseModel<HospitalDto>
			{
				Measage =  $" {Category} found",
				Status = true,
				Data = new HospitalDto
				{
					Id = caegory.Id,
					HealthCenterCategory = caegory.HealthCenterCategory,
				},
			};
        }

        public BaseResponseModel<HospitalDto> GetHospitalByLGA(string LGA)
        {
             var pharmacy =   _Hospital. GetHospitalByLGA(LGA);
            if (pharmacy == null)
            {
                return new BaseResponseModel<HospitalDto>
                {
                    Measage = "hospial Not Available", 
                    Status = false
                };
            }
            var PharmacyDTo = new HospitalDto
            {
                 HealthCenterName = pharmacy.Name,
                    HealthCenterCategory = pharmacy.HealthCenterCategory,
                    HEalthCenterEmail = pharmacy.Email,
                    HealthCenterPhoneNumber = pharmacy.PhoneNumber,
                  
                    HealthCenterImage = pharmacy.Image,
                    HoursOfWork = pharmacy.HoursOfWork,
                    // Images = (ICollection<ImageDTO>)pharmacy.images,
                    // UserId = (int)pharmacy.UserId,




                     Country =  pharmacy.Country,
                LocalGovernmentArea = pharmacy.LocalGovernmentArea,
                City = pharmacy.City,
                PostalCode = pharmacy.PostalCode,
                StreetAddress = pharmacy.StreetAddress,
                State = pharmacy.State,
            };
 
            return new BaseResponseModel<HospitalDto>
            {
                Data = PharmacyDTo,
                Measage = "Available hospitAl",
                Status = true
            };
        }

        public BaseResponseModel<HospitalDto> GetHospitalByState(string State)
        {
           var pharmacy =   _Hospital. GetHospitalByState(State);
            if (pharmacy == null)
            {
                return new BaseResponseModel<HospitalDto>
                {
                    Measage = "hospital Not Available", 
                    Status = false
                };
            }
            var pharmacyDTo = pharmacy.Select(pharmacy => new HospitalDto
            {
                Id = pharmacy.Id,
                  HealthCenterName = pharmacy.Name,
                    HealthCenterCategory = pharmacy.HealthCenterCategory,
                    HEalthCenterEmail = pharmacy.Email,
                    HealthCenterPhoneNumber = pharmacy.PhoneNumber,
                  
                    HealthCenterImage = pharmacy.Image,
                    HoursOfWork = pharmacy.HoursOfWork,

                        Country =  pharmacy.Country,
                LocalGovernmentArea = pharmacy.LocalGovernmentArea,
                City = pharmacy.City,
                PostalCode = pharmacy.PostalCode,
                StreetAddress = pharmacy.StreetAddress,
                State = pharmacy.State,

                    
                
            }).ToList();
 
            return new BaseResponseModel<HospitalDto>
            {
              
                Measage = "Available Hospital",
                Status = true
           };
        }  

        public BaseResponseModel<HospitalDto> Register(CreateHospitalRequestModel request)
        { 

            

             var regisTer = _Hospital.ExistByEmail(request.HealthCenterEmail);
            if (regisTer)
            {
                return new BaseResponseModel<HospitalDto>
                {
                    Measage = " hOSpital Already Exist",
			     	Status = false,
                };
            }

             var imageName = "";
           if(request.HealthCenterImage != null)
           {
               var imPath =  _webhost.WebRootPath;
               var imagePath = Path.Combine(imPath, "myImages");
               Directory.CreateDirectory(imagePath);
               var imageType= request.HealthCenterImage.ContentType.Split('/')[1];
              
                    imageName = $"{Guid.NewGuid()}.{imageType}";
                    var fullPath = Path.Combine(imagePath, imageName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        request.HealthCenterImage.CopyTo(fileStream);
                    }
              
              
            }
             else 
               {
                    return new BaseResponseModel<HospitalDto>
                    {
                        Measage = "file not supported!",
                        Status = false,
                    };
               }
       
               var use = new User
               {
                   Email = request.HealthCenterEmail,
                   UserName = request.HealthCenterName,
                   PhoneNumber = request.HealthCenterPhoneNumber,
                   UserFirstName = request.HealthCenterName,
                   Password = request.Password,
                   UserLastName = request.HealthCenterName,
                
               };
               var role = _Rolerepo.GetByName("Hospital");
               var userole = new UserRole
               {
                        User = use,
                    UserId = use.Id,
                    Role = role,
                    RoleId = role.Id
               };
               use.UserRoles.Add(userole);

               var HealthCenter = new Hospital
               {
                   HospitalImage = imageName,
                   Name = request.HealthCenterName,
                 
                   Email = request.HealthCenterEmail,
                   PhoneNumber = request.HealthCenterPhoneNumber,
                 //  userID = request.Id
                   User = use,
                   
                   userID  = use.Id,
                   


                    Image = imageName,
                    Country =  request.Country,
                    HoursOfWork = request.HoursOfWork,
                    HealthCenterCategory = request.HealthCenterCategory,
                   // Image = imageName,
                    LocalGovernmentArea = request.LocalGovernmentArea,
                    City = request.City,
                    PostalCode = request.PostalCode,
                    StreetAddress = request.StreetAddress,
                    State = request.State,
               };
          
             var userinfo =   _Userrepo.Create(use);
               var create =  _Hospital.Create(HealthCenter);
             
               //     var EmailDetail = new EmailDto
            // {
            //     ReceiverEmail = HealthCenter.User.Email,
            //     ReceiverName = HealthCenter.User.UserFirstName,
            
            //     Message = $"Welcome to Your Business Profile, {HealthCenter.User.UserFirstName} ",
            //     Subject = "  Welcome to Hettisential Business Profile, a free tool that helps you turn searchers on Google into loyal Users. Your account is a one-stop shop where you can manage your Business Profile to attract new Users and engage directly with existing ones.  "
            // };
              
            //   _Mail.SendEmail(EmailDetail);
            
            return new BaseResponseModel<HospitalDto>
            {
                Measage = "Hospital Successfully Created",
				Status = true,
               Data = create,
            };
        }

        public BaseResponseModel<HospitalDto> ReturnById(int id)
        {
            var Hospital = _Hospital.ExistById(id);
            if(Hospital == false)
            {
                return new BaseResponseModel<HospitalDto>
                {
                    Measage = " hospitAL doesn't exist",
                    Status = false
                };
            }
            var  NHospitAl = _Hospital.ReturnById(id);
            return new BaseResponseModel<HospitalDto>
            {
                Measage = "Hospital successfully retrieved",
                Status = true,
                Data = NHospitAl,
            };  
        }

        public BaseResponseModel<HospitalDto> Update(UpdateHospitalRequestModel request, int id)
        {
           
             var imageName = "";
           if(request.HealthCenterImage != null)
           {
               var imPath=  _webhost.WebRootPath;
               var imagePath = Path.Combine(imPath, "myImages");
               Directory.CreateDirectory(imagePath);
               var imageType= request.HealthCenterImage.ContentType.Split('/')[1];
               if(imageType=="jpeg"|| imageType=="png"||imageType=="jpg" && (request.HealthCenterImage.Length<=2000000))
               {
                    imageName = $"{Guid.NewGuid()}.{imageType}";
                    var fullPath = Path.Combine(imagePath, imageName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        request.HealthCenterImage.CopyTo(fileStream);
                    }
               }
               else 
               {
                    return new BaseResponseModel<HospitalDto>
                    {
                        Measage = "file not supported!",
                        Status = false,
                    };
               }
            }
            var admin = _Hospital.Get(id);
            if(admin ==  null)
            {
                return new  BaseResponseModel<HospitalDto>
                {
                    Measage = "Hospital doesn't exist",
                    Status = false
                };
            }
            var hospitalInfo = _Hospital.Get(id);
            var user = _Userrepo.Get(hospitalInfo.userID);
             hospitalInfo.Name = request.HealthCenterName ?? hospitalInfo.Name;
            hospitalInfo.Country = request.Country ?? hospitalInfo.City;
              hospitalInfo.City = request.City ?? hospitalInfo.City;
             hospitalInfo.StreetAddress = request.StreetAddress ?? hospitalInfo.StreetAddress;
              hospitalInfo.PostalCode = request.PostalCode ; 
              hospitalInfo.HoursOfWork = request.HoursOfWork ?? hospitalInfo.HoursOfWork;
              hospitalInfo.PhoneNumber = request.HealthCenterPhoneNumber = hospitalInfo.PhoneNumber;
              //hospitalInfo.Image = request.HealthCenterImage ?? hospitalInfo.Image;
              

                hospitalInfo.LocalGovernmentArea = request.LocalGovernmentArea ?? hospitalInfo.LocalGovernmentArea;
                 
           
        
            var newAdmin = _Hospital.Update(hospitalInfo);
              _Userrepo.Update(user);
            return new  BaseResponseModel<HospitalDto>
            {
                Measage = "Hospital successfully updated",
                Status = true,
                Data = new HospitalDto
                {
                   Id = newAdmin.Id,
                    HealthCenterName = $"{newAdmin.Name}",
                 HealthCenterImage   = imageName,
                    HEalthCenterEmail = newAdmin.Email,

                    
                          Country =  newAdmin.Country,
                LocalGovernmentArea = newAdmin.LocalGovernmentArea,
                City = newAdmin.City,
                PostalCode = newAdmin.PostalCode,
                StreetAddress = newAdmin.StreetAddress,
                State = newAdmin.State,
                    
                }
            };
        }

        BaseResponseModel<bool> IHealthCenterService.Delete(int id)
        {
            var teacher = _Hospital.Get(id);
            if(teacher == null)
            {
                return new BaseResponseModel<bool>
                {
                    Measage = "Hospital not found",
                    Status = false,
                    Data = false,
                
                };
            }
            _Hospital.Delete(teacher);
            return new BaseResponseModel<bool>
            {
                Measage = "Hospital successfully Deleted",
                Status = true,
                Data = true,
            };
        }
    }
}