using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webApiRequest
{
    public class Query
    {
        private static GraphQLHttpClient graphQLHttpClient;

        static Query()
        {
            var uri = new Uri("https://api.spacex.land/graphql");
            var graphQLOptions = new GraphQLHttpClientOptions
            {
                EndPoint = uri,
                HttpMessageHandler = new NativeMessageHandler(),
            };

            graphQLHttpClient = new GraphQLHttpClient(graphQLOptions, new NewtonsoftJsonSerializer());
        }

        public static async Task<object> ExceuteQueryReturnListAsyn<T>(string graphQLQueryType, string completeQueryString)
        {
            try
            {
                var request = new GraphQLRequest
                {
                    Query = completeQueryString
                };

                var response = await graphQLHttpClient.SendQueryAsync<object>(request);

                var stringResult = response.Data.ToString();
                //Console.WriteLine(stringResult);
                stringResult = stringResult.Replace($"\"{graphQLQueryType}\":", string.Empty);
                Console.WriteLine(stringResult);
                //stringResult = stringResult.Remove(0, 1);
                //Console.WriteLine(stringResult);
                //stringResult = stringResult.Remove(stringResult.Length - 1, 1);
                //Console.WriteLine(stringResult);

                var result = JsonConvert.DeserializeObject<Root>(stringResult);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<T> ExceuteQueryAsyn<T>(string graphQLQueryType, string completeQueryString)
        {
            try
            {
                var request = new GraphQLRequest
                {
                    Query = completeQueryString
                };
                var response = await graphQLHttpClient.SendQueryAsync<object>(request);
                var stringResult = response.Data.ToString();
                stringResult = stringResult.Replace($"\"{graphQLQueryType}\":", string.Empty);
                stringResult = stringResult.Remove(0, 1);
                stringResult = stringResult.Remove(stringResult.Length - 1, 1);

                var result = JsonConvert.DeserializeObject<T>(stringResult);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
