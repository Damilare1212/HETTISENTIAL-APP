using System.Collections.Generic;

namespace HettisentialMvc
{
    public class LoginRequestModel
    {
        public string UserName {get; set; }
        public string Email {get; set; }
        public string PassWord {get; set; }

    }

  public class LoginResponseModel
  {
    public string Name {get; set; }
    public string Email {get; set; }
    public List<RoleDto> UserRoles {get; set; }

  }

}