using CrudAspNetCoreWebAPI.Repository;
using CrudAspNetCoreWebAPI.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace CrudAspNetCoreWebAPI.Controllers
{ 


    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {



    private readonly Person _customerRepository;

    public PersonController(Person customerRepository)
    {
        _customerRepository = customerRepository;
    }


    //AllUser

    [HttpGet]

        [Route("getall")]
        public List<Person> GetAllPersons()
        {
            var db = new PersonDbContext();
            return db.Person.ToList();

        }



        //ByID

        [HttpGet]

        [Route("getperson")]
        public Person GetPerson(int id)
        {
            var db = new PersonDbContext();

            Person p = new Person();


            p = db.Person.FirstOrDefault(x => x.Id == id);
            if (p == null)
                throw new Exception("Not found");
            return p;

        }


        //post


        [Microsoft.AspNetCore.Mvc.HttpPost]

        [Route("post")]
        
        public void postPerson([FromBody] Person p)
        {
            var db = new PersonDbContext();
            db.Add(p);
            db.SaveChanges();
        }


        //put


        [Microsoft.AspNetCore.Mvc.HttpPut]

        [Route("put")]

        


        //delete

        [Microsoft.AspNetCore.Mvc.HttpDelete]

        [Route("delete")]

        public void deletePerson(int id)
        {
            var db = new PersonDbContext();
            Person p = new Person();

            if (p == null)
            {
                throw new Exception("not found");
            }
            db.Person.Remove(p);
            db.SaveChanges();
        }
        
        
       
        
       


    }


    }

        
    


