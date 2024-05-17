using Fahrschule.Infrastructure.Persistence.Common;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json.Converters;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Fahrschule.Infrastructure.Persistence
{
    public class CosmosDbManager
    {
        public static async Task<Container> Init(CosmosDbOptions options) 
        {
            try
            { 
                var clientOptions = new CosmosClientOptions()
                {
                    Serializer = new CosmosSystemTextJsonSerializer(new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        //Converters =
                        //    {
                        //        new DateTimeConverter(),
                        //        new JsonStringEnumMemberConverter()
                        //    },
                        Converters =
                        {
                            new JsonStringEnumMemberConverter()
                        },
                        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                        IgnoreReadOnlyFields = true
                    }),
                };



                //--------------------------------------------------------------------------------


                CosmosClient cosmosClient;
                if (options.AuthKeyOrResourceToken != null)
                {
                    cosmosClient = new CosmosClient(options.AccountEndpoint, options.AuthKeyOrResourceToken, clientOptions);

                    var database = await cosmosClient.CreateDatabaseIfNotExistsAsync(
                        options.DatabaseName,
                        options.DefaultDatabaseRUs);

                    await database.Database.CreateContainerIfNotExistsAsync(
                        options.ContainerName,
                        "/id");
                }
                else
                {
                    cosmosClient = new CosmosClient(options.AccountEndpoint, clientOptions);
                }

                var container = cosmosClient.GetContainer(
                options.DatabaseName,
                options.ContainerName);

                return container;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex}: Failed to initialize CosmosDB. {options.AccountEndpoint} {options.DatabaseName} {options.ContainerName}: {ex.Message}");
                throw;
            }

        }

    }
}
