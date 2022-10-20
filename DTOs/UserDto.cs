using System.Collections.Generic;

namespace HettisentialMvc
{
    public class UserDto : BaseEntity
    {
        public string UserName {get; set; }
        public string Email {get; set; }
        public ICollection<RoleDto> Roles {get; set; }
        public string UserFirstName {get; set; }
          public string UserLastName {get; set; }
          public string  UserFulName  {get; set; }
           public string Password {get; set; }
        public string ApplicationFullName {get; set; }
       
    }

    public class UpdateUserRequestModel
    {
        public string UserName {get; set; }
          public ICollection<UserRoleDto> UserRoles {get; set; }
          public string UserFullName {get; set; }
          public string AdminFullName {get; set; }
          public string Password {get; set; }


    }
}