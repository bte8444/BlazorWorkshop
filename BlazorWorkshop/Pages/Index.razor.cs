using BlazorWorkshop.Code;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWorkshop.Pages
{
  public class IndexBase : ComponentBase
  {
    protected List<Customer> Customers = new List<Customer>();
    protected string DisplayMessage = "";

    protected void CustomerSelected(Customer customer)
    {
      DisplayMessage = string.Format("Event Raised. Customer Selected: {0}",
              customer.Name);
    }

    protected override void OnInitialized()
    {
      base.OnInitialized();

      Customers.Add(
          new Customer
          {
            CustomerId = 1,
            Name = "Isadora Jarr"
          });

      Customers.Add(
          new Customer
          {
            CustomerId = 2,
            Name = "Ben Slackin"
          });

      Customers.Add(
          new Customer
          {
            CustomerId = 3,
            Name = "Doo Fuss"
          });
    }
  }
}
