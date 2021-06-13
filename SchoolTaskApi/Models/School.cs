using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolTaskApi.Models
{
    public class School
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
