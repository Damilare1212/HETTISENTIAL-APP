using HettisentialMvc.Entities.Identities;

namespace HettisentialMvc
{
    public class UserRoleDto : BaseEntity
    {
        
     public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}