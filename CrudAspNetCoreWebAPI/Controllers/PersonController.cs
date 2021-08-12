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
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace CrudAspNetCoreWebAPI.Controllers
{ 


    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {



    


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


        [HttpPost]

        [Route("post")]
        
        public void postPerson([FromBody] Person p)
        {
            var db = new PersonDbContext();
            db.Add(p);
            db.SaveChanges();
        }


        //put


        [HttpPut]

        [Route("put")]

        public IActionResult PutPerson([FromBody] Person p)
        {
            if (!ModelState.IsValid)
                return BadRequest("error");

          using(var x = new PersonDbContext())
            {
                var checkexistingPerson = x.Person.Where(c => c.Id == p.Id).FirstOrDefault<Person>();
                if(checkexistingPerson != null)
                {
                    checkexistingPerson.FirstName = p.FirstName;
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

        [HttpDelete]

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

        
    


