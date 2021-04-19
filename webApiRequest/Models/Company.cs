using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webApiRequest.Models
{
    public class Company
    {
        public Employee employee { get; set; }
    }

    public class Employee
    {
        public string name { get; set; }
        public int age { get; set; }
    }
}
