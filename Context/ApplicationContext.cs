using System;
using HettisentialMvc.Entities;
using HettisentialMvc.Entities.Identities;
using HettisentialMvc.Entities.JoinerTables;
using Microsoft.EntityFrameworkCore;
using SearchButtons;

namespace HettisentialMvc
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options)
		: base(options)
		{
             
			 
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<AdminMeasage>  AdminMeasages {get; set; }
		public DbSet<UserRole> UserRoles { get; set; }
		public DbSet<Measage> Measages { get; set; }
		public DbSet<Patient> patients {get; set; }
		public DbSet<Hospital> Hospitals { get; set; }
		public DbSet<Administrator> Administrators { get; set; }
		public DbSet<patienthospital> UserHealthCenters { get; set; }
        public DbSet<SearchButton> searchButtons {get ; set; }

		public DbSet<MedicalLab> medicalLabs { get; set; }

		public DbSet<HealthCenter> healthCenters { get; set; }
		public DbSet<Pharmacy> pharmacies { get; set; }

		public DbSet<Address> Addresses { get; set; }

		public DbSet<Image> Images { get; set; }

		public DbSet<Services> services { get; set; }

			public DbSet<HealthCenterService> healthCenterServices { get; set; }
				public DbSet<HospitalService> hospitalServices { get; set; }

					public DbSet<PharmacyService> pharmacyServices { get; set; }
                        
							public DbSet<medicalLabService> medicalLabServices { get; set; }
        











					  protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role() {Id = 1, RoleName = RoleConstant.Admin.ToString(), Description = "AdminisTrator" },
                new Role(){Id = 2,RoleName = RoleConstant.Patients.ToString(), Description = " Patients" },
				 new Role(){Id = 3,RoleName = RoleConstant.Pharmacy.ToString(), Description = " Pharmacies" },
				  new Role(){Id = 4,RoleName = RoleConstant.MedicalLAb.ToString(), Description = " MedicalLAbs" },
				   new Role(){Id = 5,RoleName = RoleConstant.HealthCenter.ToString(), Description = " HealthCenters" },
				    new Role(){Id = 6,RoleName = RoleConstant.Hospital.ToString(), Description = " Hospitals" }
					 

	 
       
               
            );
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,Email = "Mayd@yahoo.com",Password = ("password"),UserFirstName = "MasroorAhmad",UserLastName = "Yusuf",
                    PhoneNumber = "08136794915", UserName = "Damilare", 
                },
				 new User(){Id = 2,Email = "Mayd@yahoo.com",Password = ("password"),UserFirstName = "Ramon",UserLastName = "Yusuf",
                    PhoneNumber = "08136794915", UserName = "Damilare", } 


            );
            modelBuilder.Entity<Administrator>().HasData(
                new Administrator(){Id = 1,Firstname = "Ade", Lastname = "Ademola", Email = "Adex@gmail.com", Gender = Gender.Male , AdministratorType = AdminType.Administrator,   
				 Address = "Obanoko,Ibadan",UserId = 1,  DateOfBirth = DateTime.UtcNow, PhoneNumber = "090933540069"  },
                 

				   new Administrator(){Id = 2,Firstname = "Masroor", Lastname = "Ahmad", Email = "Adex@gmail.com", Gender = Gender.Male , AdministratorType = AdminType.SubAdministrator,   
				 Address = "Obanoko,lagos",UserId = 2,  DateOfBirth = DateTime.UtcNow, PhoneNumber = "090933540069"  }

				  
				 );

				 
            modelBuilder.Entity<UserRole>().HasData(new UserRole()
            {
                Id = 1,
                RoleId = 1,
                UserId = 1,
            });

			modelBuilder.Entity<Patient>().HasData(
				new Patient(){Id = 1,Firstname = "Jhon", Lastname = "Doe", Email = "Zaf@gmail.com",  gender = Gender.Male ,     
				 Address = "Cement,Lagos",  DateOfBirth = DateTime.UtcNow, PhoneNumber = "090933540069", Age = 23, UserId = 1, },


				 	new Patient(){Id = 2,Firstname = "Anita", Lastname = " balde", Email = " Anita@gmail.com",  gender = Gender.Male ,     
				 Address = "Cement,Lagos",  DateOfBirth = DateTime.UtcNow, PhoneNumber = "090933540069", Age = 23, UserId = 2,}
			);


			modelBuilder.Entity<Hospital>().HasData(
				new Hospital(){ Id = 1, Name = "Lasuth",  HospitalImage = ".-wwwroot\assets-img\news-5.jpg",
				HoursOfWork ="24 Hours Open",HealthCenterCategory = HospitalCategory.Tertiary, userID = 1  },

				new Hospital(){ Id = 2, Name = "FMC",   HospitalImage = ".-wwwroot\assets-img\news-5.jpg",
				HoursOfWork ="24 Hours Open",HealthCenterCategory = HospitalCategory.Secondary, userID= 2, }
			);


			modelBuilder.Entity<SearchButton>().HasData(
				new SearchButton(){ Id = 1, SearchKeyWord =  "FMC", NumberOfSearch = 30, },
				new SearchButton(){ Id = 2, SearchKeyWord =  "Lasuth", NumberOfSearch = 50, }
		 	);
       
			modelBuilder.Entity<Pharmacy>().HasData(
				new Pharmacy(){ Id = 1, PharmacyName ="Lufem Pharmarcy Store",Category="Private Pharmarcy",
				Email="Lufem@gmail.com",PhoneNumber="0909878765", HoursOfWork = "24 Hours Open",UserId= 1,Description="Drugs Only"  }

			);
        }







	}
}