using BlazorWorkshop.Code;
using BlazorWorkshop.Data;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorWorkshop.Pages
{
  public class IndexBase : ComponentBase
  {
    protected List<Customer> Customers = new List<Customer>();
    protected string DisplayMessage = "";
    protected Customer SelectedCustomer;

    [Inject]
    protected ICustomerService customerService { get; set; }

    protected void CustomerSelected(Customer customer)
    {
      SelectedCustomer = customer;
      DisplayMessage = string.Format("Event Raised. Customer Selected: {0}",
              customer.Name);
    }

    protected override async Task OnInitializedAsync()
    {
      Customers = await customerService.GetAllCustomers();
    }

    protected async Task CustomerResetting(int customerId)
    {
      var originalCustomer = await customerService.GetCustomer(customerId);
      if ( originalCustomer != null )
      {
        Customers[Customers.FindIndex(c => c.CustomerId == customerId)] = originalCustomer;
        SelectedCustomer = originalCustomer;
      }
    }
  }
}
