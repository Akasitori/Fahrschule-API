using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fahrschule.Contracts.Lehrers.ResponseResources
{
    public class GetAllLehrerResponseResource
    {
        [JsonPropertyName("value")]
        public List<LehrerResource>? Value { get; set; }
    }
}
