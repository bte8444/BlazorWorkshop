using BlazorWorkshop.Code;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWorkshop.Pages
{
  public class TestComponentBase : ComponentBase
  {
    [Parameter]
    public IList<Customer> Customers { get; set; } = new List<Customer> { };

    [Parameter]
    public Customer SelectedCustomer { get; set; }

    [Parameter]
    public EventCallback<Customer> CustomerSelectedEvent { get; set; }

    [Parameter]
    public EventCallback<int> CustomerResetEvent { get; set;
    }

    [Parameter]
    public EventCallback<Customer> CustomerUpdatedEvent { get; set; }

    [Parameter]
    public EventCallback<string> AddCustomerEvent { get; set; }


    [Parameter]
    public EventCallback<int> DeleteCustomerEvent { get; set; }

    protected string DisplayMessage = "";
    protected string NewCustomerName = "";

    protected async Task CustomerSelected(ChangeEventArgs args)
    {
      SelectedCustomer = (from x in Customers
                          where x.CustomerId.ToString() == args.Value.ToString()
                          select x).First();

      
      if ( CustomerSelectedEvent.HasDelegate)
      {
        await CustomerSelectedEvent.InvokeAsync(SelectedCustomer);
      }
    }

    protected async Task ResetButtonClicked()
    {
      if ( CustomerResetEvent.HasDelegate)
      {
        await CustomerResetEvent.InvokeAsync(SelectedCustomer.CustomerId);
      }
    }

    protected async Task UpdateButtonClicked()
    {
      await CustomerUpdatedEvent.InvokeAsync(SelectedCustomer);
    }

    protected async Task DeleteButtonClicked()
    {
      await DeleteCustomerEvent.InvokeAsync(SelectedCustomer.CustomerId);
    }

    protected async Task CustomerAdding()
    {
      await AddCustomerEvent.InvokeAsync(NewCustomerName);
      NewCustomerName = string.Empty;
    }
  }
}
