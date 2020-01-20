using BlazorWorkshop.Code;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorWorkshop.Data
{
  public interface ICustomerService
  {
    Task<List<Customer>> GetAllCustomers();
    Task<Customer> GetCustomer(int CustomerId);
    Task AddCustomer(Customer Customer);
  }
}