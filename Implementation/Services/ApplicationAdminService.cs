using System.Net.Mime;
// using System.Net.Mime;
using System;
 using System.Collections.Generic;
using System.IO;
using System.Linq;
 using System.Threading.Tasks;
 using HettisentialMvc.Entities;
 using HettisentialMvc.Entities.JoinerTables;
 using HettisentialMvc.Models;
using Microsoft.AspNetCore.Hosting;
using HettisentialMvc.MailClass;
// using Microsoft.AspNetCore.Hosting;
// using Org.BouncyCastle.Crypto.Generators;
// //using Org.BouncyCastle.Crypto.Generators;

namespace HettisentialMvc
 {
   
   public class AdministratorService : IApplicationAdminService
   {
       private readonly IApplicationAdminRepo _AdminRepo;
       private readonly IUserRepo _UserRepository;
		private readonly IRoleRepo _roleRepository;
        private readonly IEmailService _Mail;
      //  private readonly IEmail _mal;

        	private readonly IWebHostEnvironment _webHostEnvironment;
          public   AdministratorService (  IEmailService mail, IWebHostEnvironment webHost, IApplicationAdminRepo adminRepo,IUserRepo user,IRoleRepo Role)
          {
              _AdminRepo = adminRepo;
              _Mail = mail;
              _UserRepository = user;
              _roleRepository = Role;
              _webHostEnvironment = webHost;
             // _mal= ml;
          }

        public BaseResponseModel<AdministratorDto> Create( CreateAdminRequestModel model)
        {
            var creaTe = _AdminRepo.ExistByEmail(model.AdminEamil);
            if (creaTe )
            {
                return new BaseResponseModel<AdministratorDto>
                {
                      Measage = "Admin already exists",
                    Status = false,
                };
            }
             var imageName = "";
           if(model.AdminImage != null)
           {
               var imPath =  _webHostEnvironment.WebRootPath;
               var imagePath = Path.Combine(imPath, "myImages");
               Directory.CreateDirectory(imagePath);
               var imageType= model.AdminImage.ContentType.Split('/')[1];
              
                    imageName = $"{Guid.NewGuid()}.{imageType}";
                    var fullPath = Path.Combine(imagePath, imageName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        model.AdminImage.CopyTo(fileStream);
                    }
              
              
            }
             else 
               {
                    return new BaseResponseModel<AdministratorDto>
                    {
                        Measage = "file not supported!",
                        Status = false,
                    };
               }

              var user = new User
            {
                UserFirstName = model.FirstName,
                UserLastName = model.LAstName,
                Password = model.Password,
                Email = model.AdminEamil,
            UserName = model.UserName,
            PhoneNumber = model.PhoneNumber,
            
        
             
          
            };
           
            var role = _roleRepository.GetByName("Admin");
            var userRole = new UserRole
            {
                User = user,
                UserId = user.Id,
                Role = role,
                RoleId = role.Id
            };
            
            user.UserRoles.Add(userRole);
            var newAdmin = new Administrator
            {
              Firstname = model.FirstName,
              Lastname = model.LAstName,
              Email = model.AdminEamil,
              AdminImage =  imageName,
                User = user,
                UserId = user.Id,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                AdministratorType = model.AdminCategory
                
 
                
            };
          
          
             var userInfo =  _UserRepository.Create(user);
            var adminInfo = _AdminRepo.  Create(newAdmin);

            // try
            // {
            //         var maili = new EmailDto
            //     {
            //         ReceiverEmail = newAdmin.User.Email,
            //         ReceiverName = newAdmin.User.UserFirstName,
                    
            //         // Message = $"Hi {newAdmin.UserName} \n you are now a Subordinate Administrator Of Hettisential.... Stay  tune for more Info",
            //         // Subject= $"Thanks For RegisTration With Hettisential {newAdmin.Lastname} {newAdmin.Firstname}"


            //         Message = $"Welcome to Your Business Profile, {newAdmin.User.UserFirstName} ",
            //         Subject = "  Welcome to Hettisential Business Profile, a free tool that helps you turn searchers on Google into loyal Users. Your account is a one-stop shop where you can manage your Business Profile to attract new Users and engage directly with existing ones.  "
                
            //     };
            //     _Mail.SendEmail(maili);
            // }
            // catch (Exception e)
            // {
            //      System.Console.WriteLine(e.Message);
            // }
           

           
            return new BaseResponseModel<AdministratorDto>
            {
                Measage = "Admin successfully created",
                Status  = true,
                Data = adminInfo
            };
 
        }


        public BaseResponseModel<AdministratorDto> CreateSubadmin(CreateSubAdminRequestModel model)
        {
            throw new NotImplementedException();
        }

        public BaseResponseModel<AdministratorDto> Delete(int id)
        {
            var admin = _AdminRepo.GetById(id);
            if(admin == null)
            {
                return new BaseResponseModel<AdministratorDto>
                {
                    Measage = "Admin not found",
                    Status = false
                
                };
            }
            _AdminRepo.Delete(admin);
            return new BaseResponseModel<AdministratorDto>
            {
                Measage = "Admin successfully Deleted",
                Status = true
            };
        }

        public BaseResponseModel<AdministratorDto> GetAdminByType(AdminType AdminType)
        {
            var getbytYPE = _AdminRepo.GetAdministratorByType(AdminType);
            if (getbytYPE != null)
            {
                return new BaseResponseModel<AdministratorDto>
                {
                     Measage = $"{AdminType} get Successfuly",
					 Status = true,
                };
            }
            return new BaseResponseModel<AdministratorDto>
            {
                 Measage =  $"{AdminType} get NotFound",
					 Status = false,
            }; 

        }

        public BaseResponseModel<IList<AdministratorDto>> GetAll()
        {
             var admins = _AdminRepo.GetAll();
            if(admins == null)
            {
                return new  BaseResponseModel<IList<AdministratorDto>>
                {
                   Measage  = "No admin Found",
                    Status = false
                };
            }
            return new BaseResponseModel<IList<AdministratorDto>>
            {
                Measage = "Admin successfully retrieved",
                Status = true,
                Data = admins
            };
        }

          public BaseResponseModel<AdministratorDto> GetByEmail(string email)
        {
            var admin = _AdminRepo.ExistByEmail(email);
            if(admin == false)
            {
                return new BaseResponseModel<AdministratorDto>
                {
                    Measage = "Admin doesn't exist",
                    Status = false
                };
            }
            var newAdmin = _AdminRepo.GetByEmail(email);
            return new BaseResponseModel<AdministratorDto>
            {
                Measage = "Admin successfully retrieved",
                Status = true,
                Data = new AdministratorDto
                {
                    Id = newAdmin.Id,
                    FullName = $"{newAdmin.Firstname}{newAdmin.Lastname}",
                   
                    AdminEmail = newAdmin.Email
                }
            };
        }

        public BaseResponseModel<AdministratorDto> ReturnById(int id)
        {
            var admin = _AdminRepo.ExistById(id);
           if(admin == false)
            {
                return new BaseResponseModel<AdministratorDto>
                {
                    Measage = "Admin doesn't exist",
                    Status = false
                };
            }
            var newAdmin = _AdminRepo.ReturnById(id);
            return new  BaseResponseModel<AdministratorDto>
            {
                Measage = "Admin successfully retrieved",
                Status = true,
                Data = newAdmin
               
            }; 
        }

        public BaseResponseModel<AdministratorDto> Update(UpdateAdminRequestModel model, int id)
        {
             var imageName = "";
           if(model.AdminImage != null)
           {
               var imPath=  _webHostEnvironment.WebRootPath;
               var imagePath = Path.Combine(imPath, "myImages");
               Directory.CreateDirectory(imagePath);
               var imageType= model.AdminImage.ContentType.Split('/')[1];
               if(imageType=="jpeg"|| imageType=="png"||imageType=="jpg" && (model.AdminImage.Length<=2000000))
               {
                    imageName = $"{Guid.NewGuid()}.{imageType}";
                    var fullPath = Path.Combine(imagePath, imageName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        model.AdminImage.CopyTo(fileStream);
                    }
               }
               else 
               {
                    return new BaseResponseModel<AdministratorDto>
                    {
                        Measage = "file not supported!",
                        Status = false,
                    };
               }
            }
            var admin = _AdminRepo.ExistById(id);
            if(admin != true)
            {
                return new  BaseResponseModel<AdministratorDto>
                {
                    Measage = "Admin doesn't exist",
                    Status = false
                };
            }
            var adminInfo = _AdminRepo.GetById(id);
            var user = _UserRepository.Get(adminInfo.UserId);
            adminInfo.Firstname = model.FirstName ?? adminInfo. Firstname;
            adminInfo. Lastname =  model.LastName ?? adminInfo.Lastname;
            user.Password = model. PassWord ?? user.Password;
        
            var newAdmin = _AdminRepo.Update(adminInfo);
            _UserRepository.Update(user);
            return new  BaseResponseModel<AdministratorDto>
            {
                Measage = "Admin successfully updated",
                Status = true,
                Data = new AdministratorDto
                {
                   Id = newAdmin.Id,
                    FullName = $"{newAdmin.Firstname}{newAdmin.Lastname}",
                   AdminImage = imageName,
                    AdminEmail = newAdmin.Email
                    


        //              public string FullName {get; set; }
        // public string UserName  {get; set; }
        // public string  AdminEmail {get; set; }
        // public int UserID {get; set; }
        // public string Address {get; set; }
        // public string AdminImage {get; set; }
        // public Gender Gender {get; set; }
        // public DateTime DateOfBirth {get; set; }
        // public AdminType AdminCategory {get; set; }
        //  public string FirstName {get; set; }
        // public string LAstName {get; set; }
        
        // public string PhoneNumber {get; set; }
                }
            };
        }
    }
 
 }