using System;
using _Project.Scripts.Models;
using Newtonsoft.Json;

namespace _Project.Scripts.Response
{
    [Serializable]
    public class RegisterAgentResponse
    {
        [JsonProperty("data")] public RegisterAgentResponseData Data { get; private set; }
    }

    public class RegisterAgentResponseData
    {
        [JsonProperty("agent")] public Agent Agent { get; private set; }
        [JsonProperty("contract")] public Contract Contract { get; private set; }
        [JsonProperty("ship")] public Ship Ship { get; private set; }
        [JsonProperty("token")] public string Token { get; private set; }
    }
}