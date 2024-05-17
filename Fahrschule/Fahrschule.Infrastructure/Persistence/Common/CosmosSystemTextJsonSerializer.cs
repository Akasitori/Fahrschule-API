using Microsoft.Azure.Cosmos;
using System.Text.Json;

namespace Fahrschule.Infrastructure.Persistence.Common
{
    class CosmosSystemTextJsonSerializer : CosmosSerializer
    {

        private readonly JsonSerializerOptions _options;

        public CosmosSystemTextJsonSerializer(JsonSerializerOptions options)
        {
            _options = options;
        }


        public override T FromStream<T>(Stream stream)
        {
            if (stream.CanSeek && stream.Length == 0)
            {
                return default;
            }

            if (typeof(Stream).IsAssignableFrom(typeof(T)))
            {
                return (T)(object)stream;
            }

            using (stream)
            {
                return JsonSerializer.DeserializeAsync<T>(stream, _options, default).GetAwaiter().GetResult();
            }
        }

        public override Stream ToStream<T>(T input)
        {
            var streamPayload = new MemoryStream();
            JsonSerializer.SerializeAsync(streamPayload, input, typeof(T), _options, default);
            streamPayload.Position = 0;
            return streamPayload;
        }
    }
}
