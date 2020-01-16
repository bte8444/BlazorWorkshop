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
    public EventCallback<Customer> CustomerSelectedEvent { get; set; }

    protected Customer SelectedCustomer;
    protected string DisplayMessage = "";

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

  }
}
