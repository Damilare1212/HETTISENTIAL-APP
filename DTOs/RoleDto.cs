using System.Collections.Generic;

namespace HettisentialMvc
{
    public class RoleDto : BaseEntity
    {
        public string RoleName {get; set; }
        public string Description {get; set; }
        
        // public List<UserDto> User{get;set;} = new List<UserDto>();

    }
     public class CreateRoleRequestModel
    {
        public string RoleName{get;set;}  
         public string Description {get; set; }
 
    }
    public class UpdateRoleRequestModel
    {
         public string Description {get; set; }

        public string RoleName{get;set;}
    }
}