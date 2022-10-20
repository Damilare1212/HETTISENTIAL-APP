// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using HettisentialMvc.Interface;
// using HettisentialMvc.Models;

// namespace HettisentialMvc
// {
//     public class AdminMessageService : IAdminMessageService
//     {
//         private readonly IAdminMessageRepo _AdminMessageRepo;
//         private readonly  IApplicationUserRepo _ApplicationUserRepo;
//         private readonly Imeasagesender _MessageSender;
//         private readonly IMeasageRepo _MessageRepo;
       
//         private readonly IApplicationUserAdminMessageRepo _ApplicationUserAdminMessageRepo;
       
//         public AdminMessageService(IMeasageRepo MessageRepo,IAdminMessageRepo AdminmessageRepo,IApplicationUserRepo ApplicationUserRepo,Imeasagesender MessageSender,IApplicationUserAdminMessageRepo AppUserAdminMesageRepo)
//         {
//             _AdminMessageRepo = AdminmessageRepo;
//             _ApplicationUserAdminMessageRepo = AppUserAdminMesageRepo;
//             _MessageSender = MessageSender;
//             _ApplicationUserRepo = ApplicationUserRepo;
//             _MessageRepo = MessageRepo;

//         }

//         public async  Task<BaseResponseModel<AdminMeassageDTO>> CreateAdminMessage(CreateAdminMessageRequestModel model, int UserId )
//         {
//           var messageInDb = await _MessageRepo.GetMeasageByMessageType(model.MeasageType);
//             string messageReturned = messageInDb.MessageContent;
//             var user = await _ApplicationUserRepo.GetUser(UserId);
//             var userEmail = user.Email;
//             if(messageReturned== null)
//              return new BaseResponseModel<AdminMeassageDTO>
//             {
//                Measage = "Message Not Sent",
//                Status = false,
//             };
//             var adminMessage = new AdminMeasage
//             {
               
//                 DateSent = DateTime.UtcNow,
//                       MessageContent = messageReturned,
//                       MessageSubject = model.MeasageSubject,
//                       MesageType = model.MeasageType, 
//             };
            
//             var appUserAdminMessage = new ApplicationUserAdminMeasage
//             {
//                AdminMessage = adminMessage,
//                AdminMessageId = adminMessage.Id,
//                ApplicationUser = user,
//                ApplicationUserId = user.Id,
             
//             };
//             adminMessage.ApplicationUserAdminMessages.Add(appUserAdminMessage);
//             var sentStatus = _MessageSender.SendMailToSingleUser(model.MessageSubject, userEmail,messageReturned);
//             await _AdminMessageRepo.Create(adminMessage);
//             return new BaseResponseModel<AdminMeassageDTO>
//             {
//               Measage = sentStatus,
//               Status = true,
//               Data = new AdminMeassageDTO
//               {
//                   Id = adminMessage.Id,
//                 DateSent = adminMessage.DateSent,
//                 MeasageContent = adminMessage.MessageContent,
//                 MessageSubject = adminMessage.MessageSubject,
//                 MessageType = adminMessage.MesageType,
//               }
//             };
//         } 

//         public async Task<BaseResponseModel<AdminMeassageDTO>> CreateMessageToManyUsers(CreateAdminMessageRequestModel model)
//         {
//             var ManyMessage = await _MessageRepo
//             .GetMeasageByMessageType(model.MeasageType);
//             string Message = ManyMessage.MessageContent;
//             var users = await _ApplicationUserRepo.GetAllUser();
//             List<int> UserIds = users
//             .Select(A => A.Id )
//             .ToList();
//              var usersEmails = users.Select
//              (L=> L.Email).ToList();
//              var SelectUsers = await _ApplicationUserRepo
//              .GetSelectedUsers(UserIds);
//             if (Message == null )
//             return new BaseResponseModel<AdminMeassageDTO>
//             {
//                 Measage = "Message Not Created",
//                 Status = false,
//             } ;
//             var adminmessage = new AdminMeasage
//             {
//                 DateSent = DateTime.UtcNow,
//                 MessageContent = Message,
//                 MessageSubject = model.MeasageSubject,
//                 MesageType = model.MeasageType,
//             };

//             foreach (var it in SelectUsers)
//             {
//                 var ADminmessage =  new ApplicationUserAdminMeasage
//                 {
//                      ApplicationUserId = it.Id,
//                     ApplicationUser = it,
//                     AdminMessage = adminmessage,
//                     AdminMessageId = adminmessage.Id,
//                 };
//                 adminmessage.ApplicationUserAdminMessages.Add(ADminmessage);
//             }
//               var sentStatus =  _MessageSender.SendMailToMultipleUser(model.MeasageSubject, usersEmails,Message);
//             await _AdminMessageRepo.Create(adminmessage);
//             return new BaseResponseModel<AdminMeassageDTO>
//             {
//                      Measage =sentStatus,
//                      Status = true,
//                      Data = new AdminMeassageDTO
//                      {
//                          Id = adminmessage.Id,
//                          DateSent = adminmessage.DateSent,
//                          MeasageContent = adminmessage.MessageContent,
//                          MessageSubject = adminmessage.MessageSubject,
//                          MessageType = adminmessage.MesageType,
//                      }
//             };
//         }

//         public Task<bool> Delete(int Id)
//         {
//             throw new System.NotImplementedException();
//         }

//         public Task<BaseResponseModel<AdminMeassageDTO>> GetAdminMessage(int Id)
//         {
//             throw new System.NotImplementedException();
//         }

//         public Task<IEnumerable<ApplicationUSerAdminMeasageDTO>> GetAllAdminMessage()
//         {
//             throw new System.NotImplementedException();
//         }

//         public async Task<BaseResponseModel<AdminMeassageDTO>> UpdateMessage(UpdateAdminMeasageRequestModel model, int Id)
//         {
//               var adminMessage = await _AdminMessageRepo.GetAdminMessage(Id);
//            if(adminMessage == null) return new BaseResponseModel<AdminMeassageDTO>
//            {
//                Measage = "Failed To Update",
//                Status = false,
//            };
//            adminMessage.DateSent = model.DateSent;
//           adminMessage.MessageSubject = adminMessage.MessageSubject ?? model.MessageSubject;
//           adminMessage.MesageType = adminMessage.MesageType;
//            await _AdminMessageRepo.Update(adminMessage);
//            return new BaseResponseModel<AdministratorDto>
//            {
//                Measage = "Update Successful",
//                Status = true,
//                Data = new AdminMeassageDTO
//                {
//                    Id = adminMessage.Id,
//                        DateSent = adminMessage.DateSent,
//                     MeasageContent = adminMessage.MessageContent,
//                    MessageSubject = adminMessage.MessageSubject,
//                      MessageType = adminMessage.MesageType,  
//                      ApplicationUSerAdminMeasageDTO = adminMessage.ApplicationUserAdminMessages
//                      .Select( L=> new ApplicationUSerAdminMeasageDTO
//                      {
//                              Id = L.Id,
//                           AdminMeasage = L.AdministratorMessage.MessageContent,
//                            AdminMessageID = L.AdministratorMessageId,
//                             App = L.ApplicationUserId,
//                             ApplicationUserName = L.ApplicationUser.User.UserName,
//                      }).ToList()
//                }
//            };
//         }
//     }
// }