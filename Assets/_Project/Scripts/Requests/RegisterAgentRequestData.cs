﻿using Newtonsoft.Json;
using SVT.Networking;

namespace _Project.Scripts.Requests
{
    public class RegisterAgentRequestData : WebRequestData
    {
        public RegisterAgentRequestData(string symbol, string faction)
        {
            Symbol = symbol;
            Faction = faction;
        }

        [JsonProperty("symbol")] public string Symbol { get; }
        [JsonProperty("faction")] public string Faction { get; }

        public override string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}