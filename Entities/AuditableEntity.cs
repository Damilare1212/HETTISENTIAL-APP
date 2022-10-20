using System;

namespace HettisentialMvc
{
    public class AuditableEntity : BaseEntity
    {
         public bool IsDeleted { get; set; } 
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }


            // string CreatedBy { get; set; }
            // DateTime CreatedAt { get; set; }
            // string LastModifiedBy { get; set; }
            // DateTime LastModifiedAt { get; set; }

         
            // public string CreatedBy { get; set; }
            // public DateTime CreatedOnUtc { get; set; }
            // public string LastModifiedBy { get; set; }
            // public DateTime? LastModifiedOnUtc { get; set; }
            // public string IPAddress { get; set; }
            // public bool IsDeleted { get; set; }


        //  public int CreatedBy { get; set; }
        // public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        // public int LastModifiedBy { get; set; } 
        // public DateTime? LastModifiedOn { get; set; } 
        // // public DateTime? DeletedOn { get; set; }
        // public int? DeletedBy { get; set; }
        // public bool IsDeleted { get; set; }
        
        // public int Id {get;set;}
        // public string CreatedBy {get;set;} 
        // public string ModifiedBy {get;set;}
        // public DateTime DateCreated {get;set;} 
        // public DateTime DateModified{get;set;} 
        // public bool IsDeleted{get;set;}

    }
}