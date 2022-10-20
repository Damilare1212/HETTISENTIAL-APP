namespace HettisentialMvc
{
    public class patienthospital : AuditableEntity
    {
        public int HealthCenterId {get; set; }
        public Hospital Hospital {get; set; }
        public int userId {get; set; }
        public User User {get; set; }
    }
}