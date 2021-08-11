using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CrudAspNetCoreWebAPI.Repository.Models
{
    [Table("Person")]
    public partial class Person
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [Column("phoneNumber")]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        internal void Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
