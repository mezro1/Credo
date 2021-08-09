using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;


namespace WebApi.Controllers
{
    public class CustomerController : ApiController
    {
        //store by id
        public IHttpActionResult GetCustomer(int id)
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();
            using (var x = new CrudEntities())
            {
                var customer = x.Customers.SingleOrDefault(a => a.Id == id);
                if (customer == null)
                {
                    return NotFound();
                }
                customerViewModel.Id = customer.Id;
                customerViewModel.Name = customer.Name;
                customerViewModel.Mail = customer.Mail;
                customerViewModel.Address = customer.Address;
                customerViewModel.Phone = customer.Phone;
                customerViewModel.Age = customer.Age;
            }
            return Ok(customerViewModel);
        }


        //Get data
        public IHttpActionResult GetAllCustomer()
        {
            IList<CustomerViewModel> customers = null;
            using (var x = new CrudEntities())
            {
                customers = x.Customers
                    .Select(c => new CustomerViewModel()

                    {
                        Id= c.Id,
                        Name = c.Name,
                        Mail = c.Mail,
                        Address = c.Address,
                        Phone = c.Phone,
                        Age = c.Age
                    }

                    ).ToList<CustomerViewModel>();
            }
            if (customers.Count == 0)
                return NotFound();
            return Ok(customers);



        }
        


        //Insert
        public IHttpActionResult PostNewCustomer(CustomerViewModel customer)
        {
            if (!ModelState.IsValid)
                return BadRequest("არასწორი მონაცემები");


            using (var x = new CrudEntities())
            {
                x.Customers.Add(new Customer()
                {

                    Name = customer.Name,
                    Mail = customer.Mail,
                    Address = customer.Address,
                    Phone = customer.Phone,
                    Age = customer.Age


                });

                x.SaveChanges();
            }
            return Ok();

        }

        //Update
        public IHttpActionResult PutCustomer(CustomerViewModel customer)
        {
            if (!ModelState.IsValid)
                return BadRequest("არასწორი მონაცემები");
            using (var x = new CrudEntities())
            {
                var checkExsitingCustomer = x.Customers.Where(c => c.Id == customer.Id).FirstOrDefault<Customer>();

                if (checkExsitingCustomer != null){
                    
                    checkExsitingCustomer.Name = customer.Name;
                    checkExsitingCustomer.Mail = customer.Mail;
                    checkExsitingCustomer.Address = customer.Address;
                    checkExsitingCustomer.Phone = customer.Phone;
                    checkExsitingCustomer.Age = customer.Age;
                    x.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }

        //delete
        public IHttpActionResult Delete(int Id)
        {
            if(Id <= 0)
            {
                return BadRequest("არასწორი ID");
            }

            using (var x = new CrudEntities())
            {
                var customer = x.Customers
                    .Where(c => c.Id == Id)
                    .FirstOrDefault();
                x.Entry(customer).State = System.Data.Entity.EntityState.Deleted;
                x.SaveChanges();
            }
            return Ok();
        }

    }
}
