using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Stage>(myJsonResponse);

    public class Stage
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("performer")]
        public string Performer { get; set; }
    }


}
