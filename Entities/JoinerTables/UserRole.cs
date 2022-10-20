using HettisentialMvc.Entities.Identities;

namespace HettisentialMvc.Entities.JoinerTables
{
    public class UserRole : AuditableEntity
    {
         public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public Measage Measage {get; set; }
    }
}