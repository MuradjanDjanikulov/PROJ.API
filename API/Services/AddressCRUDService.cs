


using DataAccess;
using DataAccess.Entity;
using PROJ.API.Models;

namespace PROJ.API.Services
{
    public class AddressCRUDService : IGenericCRUDService<AddressModel>
    {
        private readonly IGenericRepository<Address> _addressRepository;

        public AddressCRUDService(IGenericRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<AddressModel> Create(AddressModel model)
        {

            var address = new Address(model.AddressLine, model.Country, model.City);
            Address createdAddress = await _addressRepository.Create(address);
            var result = new AddressModel(createdAddress.Id, createdAddress.AddressLine, createdAddress.Country, createdAddress.City);
            return result;

        }

        public async Task<bool> Delete(int id)
        {
            return await _addressRepository.Delete(id);

        }

        public async Task<AddressModel> Get(int id)
        {
            var address = await _addressRepository.Get(id);
            var model = new AddressModel(address.Id, address.AddressLine, address.Country, address.City);
            return model;
        }

        public async Task<IEnumerable<AddressModel>> GetAll()
        {
            var result = new List<AddressModel>();
            var addresses = await _addressRepository.GetAll();
            foreach (var address in addresses)
            {
                var model = new AddressModel(address.Id, address.AddressLine, address.Country, address.City);
                result.Add(model);
            }
            return result;
        }

        public async Task<AddressModel> Update(int id, AddressModel model)
        {
            var address = new Address(model.Id, model.AddressLine, model.Country, model.City);
            var updatedAddress = await _addressRepository.Update(id, address);
            var result = new AddressModel(updatedAddress.Id, updatedAddress.AddressLine, updatedAddress.Country, updatedAddress.City);
            return result;
        }

        /*        public async Task<AddressModel> UpdatePatch(int id, JsonPatchDocument employee)
                {
                    throw new NotImplementedException();
                }
        */
    }
}
