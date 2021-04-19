using GraphQL;
using GraphQL.Client;
using GraphQL.Client.Serializer.Newtonsoft;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using webApiRequest.Models;

namespace webApiRequest
{
    public class Program
    {
        static async Task Main()
        {
            //Root AllEmployees = new Root();
            string completeQuery = "query{company{ceo,coo,cto,cto_propulsion,employees}}";
            string graphQLQueryType = "missions";

            var result = await Query.ExceuteQueryReturnListAsyn<Root>(graphQLQueryType, completeQuery);
            //AllEmployees = result;
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
