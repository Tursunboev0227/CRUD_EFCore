using MyApplication.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Domain.Entities.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int age { get; set; }
        public Status status { get; set; }
    }
}
