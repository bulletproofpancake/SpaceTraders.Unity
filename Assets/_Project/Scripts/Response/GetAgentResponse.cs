using _Project.Scripts.Models;
using Newtonsoft.Json;

namespace _Project.Scripts.Response
{
    public class GetAgentResponse
    {
        [JsonProperty("data")] public Agent Agent { get; private set; }
    }
}