using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful_API.DomainModels
{
    public class Trip
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
