using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webApiRequest
{
    public class company
    {
        public string ceo { get; set; }
        public string coo { get; set; }
        public string cto { get; set; }
        public string cto_propulsion { get; set; }
        public int employees { get; set; }

        public override string ToString()
        {
            return $"Ceo: {ceo},\n" +
                $"Coo: {coo},\n" +
                $"Email: {cto},\n" +
                $"Age: {cto_propulsion},\n" +
                $"DepartmentId: {employees},\n";
        }
    }

    public class Root
    {
        public company company { get; set; }
    }

   
}
