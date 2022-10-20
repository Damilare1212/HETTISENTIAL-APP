

using System.Collections.Generic;

namespace HettisentialMvc
{
    public class AddressService : IAddressService
    {
          private readonly IAddressRepo _AddressRepo;
        //   private readonly Pharmacy phar;
        //     private readonly MedicalLab med;
        //       private readonly Hospital hos;
        //         private readonly HealthCent // phar = pharmarcy;
            // med = medical;
            // hos = hospital;
            // health = healthCenter;er health;
                   
         
        public AddressService(    IAddressRepo AddressRepo)
        {
            _AddressRepo = AddressRepo;
           
        }
        public BaseResponseModel<AddressDTo> Create(CreateAddressRequestModel model)
        {
          

            if (model == null)
            {
                return new BaseResponseModel<AddressDTo>
                {
                    Measage = "Address Can`t be null",
                    Status = false,
                };
            }
           
            var phar = new Pharmacy{};
             var med = new MedicalLab{};
              var hos = new Hospital{};
               var health = new HealthCenter{};
          
            var add = new Address
            {  Country = model.Country,
                StreetAddress= model.StreetAddress,
                LocalGovernmentArea= model.LocalGovernmentArea,
                City = model.City,
                PostalCode = model.PostalCode,
                State = model.State,
                PharmacyID =  phar.Id,
                medicalLabID = med.Id,
                hospitalID = hos.Id,
                healthCenterID = health.Id,
                

            };
            _AddressRepo.Create(add);
            return new BaseResponseModel<AddressDTo>{
                Status = true,
                Measage = "Address Created Successfully",
            };
        }

        public BaseResponseModel<AddressDTo> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public BaseResponseModel<IList<AddressDTo>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public BaseResponseModel<AddressDTo> ReturnById(int id)
        {
            var Adderess = _AddressRepo.ExistById(id);
            if(Adderess == false)
            {
                return new BaseResponseModel<AddressDTo>
                {
                    Measage = " Adderess doesn't exist",
                    Status = false
                };
            }
            var NAdderess = _AddressRepo.ReturnById(id);
            return new BaseResponseModel<AddressDTo>
            {
                Measage = "Adderess successfully retrieved",
                Status = true,
                Data = NAdderess
            };         
        }

        public BaseResponseModel<AddressDTo> Update(UpdateAddressRequestModel model, int id)
        {
            if (model == null )
            {
                return new BaseResponseModel<AddressDTo>
                {
                    Status = false,
                    Measage = "Value cannot Be null"
                };
            }
             var get = _AddressRepo.GetById(id);
             if (get == null)
             {
                 return new BaseResponseModel<AddressDTo>
                 {
                      Status = false,
                    Measage = "Value cannot Be null"
                 };
             }
              


             get.City = model.City?? get.City;
              get.Country = model.Country?? get.Country;
                get.StreetAddress = model.StreetAddress?? get.StreetAddress;
                get.LocalGovernmentArea = model.LocalGovernmentArea?? get.LocalGovernmentArea;
                get.PostalCode = model.PostalCode  ;
                get.State = model.State?? get.State; 
                 _AddressRepo.Update(get);
                   return new BaseResponseModel<AddressDTo>
                   {
                     Status = true,
                     Measage = "Address Updated Successfully",
                   }  ;           
        }
    }
}