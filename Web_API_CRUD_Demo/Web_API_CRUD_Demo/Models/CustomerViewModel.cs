using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_API_CRUD_Demo.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Age { get; set; }
    }
}