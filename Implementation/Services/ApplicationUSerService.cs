using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.IO;
using HettisentialMvc.Entities.JoinerTables;
using Microsoft.AspNetCore.Hosting;

namespace HettisentialMvc
{
    public class ApplicationUSerService : IApplicationUSerService
    {
         private readonly IApplicationUserRepo  _AppUserRepo;
         private readonly IUserRepo _UserRepo;
          private readonly IRoleRepo _RoleRepo;
          private readonly IWebHostEnvironment _Webhostenvironment;

          public ApplicationUSerService(IApplicationUserRepo applicationUser,IUserRepo userRepo,IRoleRepo roleRepo,IWebHostEnvironment Webhost)
          {
              _AppUserRepo = applicationUser;
              _UserRepo = userRepo;
              _RoleRepo = roleRepo;
              _Webhostenvironment = Webhost;
              
          }

              

        



        public BaseResponseModel<PatientDto> Create(CreatePatientRequestModel model)
        {
           
            var user = _AppUserRepo.ExistByEmail(model.Email);
            if (user)
            {
                return new BaseResponseModel<PatientDto>
                {
                    Measage = "  Patient   Already Exist ",
                    Status = false,
                };
                
            }

           var imageName = "";
           if(model.Image != null)
           {
               var imPath =  _Webhostenvironment.WebRootPath;
               var imagePath = Path.Combine(imPath, "myImages");
               Directory.CreateDirectory(imagePath);
               var imageType= model.Image.ContentType.Split('/')[1];
              
                    imageName = $"{Guid.NewGuid()}.{imageType}";
                    var fullPath = Path.Combine(imagePath, imageName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        model.Image.CopyTo(fileStream);
                    }
              
              
            }
             else 
               {
                    return new BaseResponseModel<PatientDto>
                    {
                        Measage = "file not supported!",
                        Status = false,
                    };
               }
          var userr = new User
          {
              UserFirstName = model.FirstName,
              UserLastName = model.LastName,
              Email = model.Email,
                Password = model.Password,
                PhoneNumber = model.Phonenumber,
                UserName = model.UserName,


          };
          var role = _RoleRepo.GetByName("Patients");
          var userrole = new UserRole
          {
              User = userr,
              Role = role,
              UserId = userr.Id,
              RoleId = role.Id,

          };
          userr.UserRoles.Add(userrole);
          var appuser = new Patient
          {
              Firstname = model.FirstName,
              Lastname = model.LastName,
              gender = model.Gender,
              DateOfBirth = model.DateOfbirth,
              Email = model.Email,
              User = userr,
              UserId = userr.Id,
              
              UserImage =  imageName,
              PhoneNumber = model.Phonenumber,
              Address = model.Adderess,

          };
          _UserRepo.Create(userr);
            var app = _AppUserRepo.Create(appuser);
            return new BaseResponseModel<PatientDto>
            {
                Measage = "ApplicationUser Created successfully",
                Status = true,
            };
        }

        

        public BaseResponseModel<PatientDto> Update(UpdatePatientRequestModel model, int id)
        {
            var imageName = "";
           if(model.Image != null)
           {
               var imPath= _Webhostenvironment.WebRootPath;
               var imagePath = Path.Combine(imPath, "myImages");
               Directory.CreateDirectory(imagePath);
               var imageType= model.Image.ContentType.Split('/')[1];
               if(imageType=="jpeg"|| imageType=="png"||imageType=="jpg" && (model.Image.Length<=2000000))
               {
                    imageName = $"{Guid.NewGuid()}.{imageType}";
                    var fullPath = Path.Combine(imagePath, imageName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        model.Image.CopyTo(fileStream);
                    }
               }
               else
               {
                    return new BaseResponseModel<PatientDto>
                    {
                        Measage = "file not supported!",
                        Status = false,
                    };
               }
          }

            var student = _AppUserRepo.ExistById(id);
            if(student != true)
            {
                return new BaseResponseModel<PatientDto>
                {
                    Measage = "Student doesn't exist",
                    Status = false
                };
            }
            var studentInfo = _AppUserRepo.Get(id);
            var user = _UserRepo.Get(studentInfo.UserId);
            studentInfo.Firstname = model.FirstName ?? studentInfo.Firstname;
            studentInfo.Lastname = model.LastName ?? studentInfo.Lastname;
          //  user.Password = model.Password ?? user.Password;
            var newStudent = _AppUserRepo.Update(studentInfo);
            _UserRepo.Update(user);
            return new BaseResponseModel<PatientDto>
            {
                Measage = "Student successfully updated",
                Status = true,
                Data = new PatientDto
                {
                     Fullname = $"{newStudent.Firstname} {newStudent.Lastname}", 
                    Email = newStudent.Email,
                     Image = imageName,
                }
            };
        }

        BaseResponseModel<PatientDto> IApplicationUSerService.Delete(int id)
        {
            var appuser = _AppUserRepo.Get(id);
            if (appuser == null)
            {
                return new BaseResponseModel<PatientDto>
                {
                    Measage = "ApplicationUser NoTFound",
                    Status = true,
                };
            }
             _AppUserRepo.Delete(appuser);
             return new BaseResponseModel<PatientDto>
             {
                 Measage = "ApplicaionUser Deleed Successfuly",
                 Status = true,
             };
        }

        BaseResponseModel<IList<PatientDto>> IApplicationUSerService.GetAll()
        {
            var appuser = _AppUserRepo.GetAll();
            if (appuser == null)
            {
                return new BaseResponseModel<IList<PatientDto>>
                {
                    Measage = "ApplicationUser NoTFound",
                    Status = false,
                };
            }
            return new BaseResponseModel<IList<PatientDto>>
            {
                 Measage = "ApplicaionUser Deleed Successfuly",
                 Status = true,
                 Data = appuser,
            };
        }

        BaseResponseModel<PatientDto> IApplicationUSerService.GetByEmail(string email)
        {
              var student = _AppUserRepo.ExistByEmail(email);
            if(student == false)
            {
                return new BaseResponseModel<PatientDto>
                {
                    Measage = "AppUser doesn't exist",
                    Status = false
                };
            }
            var newStudent = _AppUserRepo.GetByEmail(email);
            return new BaseResponseModel<PatientDto>
            {
                Measage = "Appuser successfully retrieved",
                Status = true,
                Data = new PatientDto
                {
                    Id = newStudent.Id,
                    Fullname = $"{newStudent.Firstname} {newStudent.Lastname}",
                    
                    Email = newStudent.Email,
                   
                   
                }
            };
        }

        BaseResponseModel<PatientDto> IApplicationUSerService.ReturnById(int id)
        {
            var student = _AppUserRepo.ExistById(id);
            if(student == false)
            {
                return new BaseResponseModel<PatientDto>
                {
                    Measage = " Appuser doesn't exist",
                    Status = false
                };
            }
            var newStudent = _AppUserRepo.ReturnById(id);
            return new BaseResponseModel<PatientDto>
            {
                Measage = "Appuser successfully retrieved",
                Status = true,
                Data = newStudent
            }; 
        }
    }
}