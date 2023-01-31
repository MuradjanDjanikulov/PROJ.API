using DataAccess;
using DataAccess.Entity;
using PROJ.API.Models;

namespace PROJ.API.Services
{
    public class EmployeeCRUDService : IGenericCRUDService<EmployeeModel>
    {
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IGenericRepository<Address> _addressRepository;
        
        public EmployeeCRUDService(IGenericRepository<Employee> employeeRepository,IGenericRepository<Address> addressRepository)
        {
            _employeeRepository = employeeRepository;
            _addressRepository = addressRepository;
        }

        public async Task<EmployeeModel> Create(EmployeeModel model)
        {
            var existingAddress = await _addressRepository.Get(model.AddressId);
            var employee = new Employee(model.FullName, model.Development, model.Email);
            if (existingAddress!=null)
            {
                employee.Address = existingAddress;
            }
            Employee createdEmployee = await _employeeRepository.Create(employee);
            var result = new EmployeeModel(createdEmployee.Id,createdEmployee.FullName,createdEmployee.Development,createdEmployee.Email,existingAddress.Id);
            
            return result;

        }

        public async Task<bool> Delete(int id)
        {
            return await _employeeRepository.Delete(id);
        }

        public async Task<EmployeeModel> Get(int id)
        {
            var employee= await _employeeRepository.Get(id);
            var model = new EmployeeModel(employee.Id, employee.FullName, employee.Development, employee.Email);
            return model; 
        }

        public async Task<IEnumerable<EmployeeModel>> GetAll()
        {
            var result = new List<EmployeeModel>();
            var employees=await _employeeRepository.GetAll();
            foreach (var employee in employees)
            {
                var model = new EmployeeModel(employee.Id, employee.FullName, employee.Development, employee.Email);
                result.Add(model);
            }
            return result;
        }

        public async Task<EmployeeModel> Update(int id, EmployeeModel model)
        {
            Address address = await _addressRepository.Get(model.AddressId);
            var employee = new Employee(model.FullName, model.Development, model.Email);
            if(address != null) 
            { 
                employee.Address = address; 
            }
            var updatedEmployee=await _employeeRepository.Update(id, employee);
            var result = new EmployeeModel(updatedEmployee.Id,updatedEmployee.FullName,updatedEmployee.Development, updatedEmployee.Email);
            return result;
        }

/*        public async Task<EmployeeModel> UpdatePatch(int id, JsonPatchDocument employee)
        {
            throw new NotImplementedException();
        }
*/    
    }
}
