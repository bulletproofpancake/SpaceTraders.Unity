using Newtonsoft.Json;

namespace _Project.Scripts.Models
{
    public class Agent
    {
        [JsonProperty("accountId")] public string AccountID { get; private set; }
        [JsonProperty("symbol")] public string Symbol { get; private set; }
        [JsonProperty("headquarters")] public string Headquarters { get; private set; }
        [JsonProperty("credits")] public int Credits { get; private set; }
        [JsonProperty("startingFaction")] public string StartingFaction { get; private set; }
        [JsonProperty("shipCount")] public string ShipCount { get; private set; }
    }
}