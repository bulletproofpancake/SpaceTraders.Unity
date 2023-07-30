using Newtonsoft.Json;

namespace _Project.Scripts.Models
{
    public class Faction
    {
        [JsonProperty("symbol")] public string Symbol { get; private set; }
        [JsonProperty("name")] public string Name { get; private set; }
        [JsonProperty("description")] public string Description { get; private set; }
        [JsonProperty("headquarters")] public string Headquarters { get; private set; }
        [JsonProperty("traits")] public Trait[] Traits { get; private set; }
        [JsonProperty("isRecruiting")] public bool IsRecruiting { get; private set; }
    }

    public class Trait
    {
        [JsonProperty("symbol")] public string Symbol { get; private set; }
        [JsonProperty("name")] public string Name { get; private set; }
        [JsonProperty("description")] public string Description { get; private set; }
    }
}