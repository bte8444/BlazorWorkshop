using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWorkshop.Code;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWorkshop.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomerController : ControllerBase
  {
    // GET: api/Customer
    //[Route("api/Customer")]
    [HttpGet]
    public IEnumerable<Customer> Get() => GetAllCustomers();



    // GET: api/Customer/5
    [HttpGet("{id}", Name = "Get")]
    public Customer Get(int id)
    {
      return GetAllCustomers().FirstOrDefault(c => c.CustomerId == id);
    }

    //// POST: api/Customer
    //[HttpPost]
    //public void Post([FromBody] string value)
    //{
    //}

    //// PUT: api/Customer/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    //// DELETE: api/ApiWithActions/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}


    private IEnumerable<Customer> GetAllCustomers()
    {
      var customers = new List<Customer>();
      customers.Add(
                new Customer
                {
                  CustomerId = 1,
                  Name = "Isadora Jarr"
                });

      customers.Add(
          new Customer
          {
            CustomerId = 2,
            Name = "Ben Slackin"
          });

      customers.Add(
          new Customer
          {
            CustomerId = 3,
            Name = "Doo Fuss"
          });

      customers.AddRange(new Customer[]
      {
        new Customer { CustomerId = 4, Name = "Hugh Jass"},
        new Customer { CustomerId = 5, Name = "Donatella Nawan"},
        new Customer { CustomerId = 6, Name = "Pykop Andropov"}
      });
      return customers;

    }
  }
}
