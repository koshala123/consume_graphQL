using System;
using System.ComponentModel;
using System.Threading.Tasks;


namespace webApiRequest
{
    public class Program
    {
        static async Task Main()
        {
            string completeQuery = "query{company{ceo,coo,cto,cto_propulsion,employees}}";
            string graphQLQueryType = "missions";

            var result = await Query.ExceuteQueryReturnListAsyn<Root>(graphQLQueryType, completeQuery);
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(result))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(result);
                Console.WriteLine("{0}={1}", name, value);
            }
            Console.ReadLine();
        }
    }
}
