using System.Collections.Generic;
using HettisentialMvc.Entities.JoinerTables;

namespace HettisentialMvc.Entities.Identities
{
    public class Role : AuditableEntity
    {
        
       
        public string  RoleName { get; set; }
        public string Description { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    }

    
}