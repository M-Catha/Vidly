using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _DBContext;

        public CustomersController()
        {
            _DBContext = new ApplicationDbContext();
        }

        // GET /api/customers
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _DBContext.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>);
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomerByID(int id)
        {
            var customer = _DBContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null) return NotFound();

            var customerDTO = Mapper.Map<Customer, CustomerDTO>(customer);

            return Ok(customerDTO);
        }

        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
            _DBContext.Customers.Add(customer);
            _DBContext.SaveChanges();

            customerDTO.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDTO);
        }

        // PUT /api/cuastomers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);

            var existingCustomer = _DBContext.Customers.SingleOrDefault(c => c.Id == id);

            if (existingCustomer == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDTO, existingCustomer);

            _DBContext.SaveChanges();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var existingCustomer = _DBContext.Customers.SingleOrDefault(c => c.Id == id);

            if (existingCustomer == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            _DBContext.Customers.Remove(existingCustomer);
            _DBContext.SaveChanges();
        }
    }
}
