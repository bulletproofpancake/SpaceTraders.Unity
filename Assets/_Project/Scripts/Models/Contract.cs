using System;
using Newtonsoft.Json;

namespace _Project.Scripts.Models
{
    public enum ContractType
    {
        PROCUREMENT,
        TRANSPORT,
        SHUTTLE
    }

    public class Contract
    {
        [JsonProperty("id")] public string Id { get; private set; }
        [JsonProperty("factionSymbol")] public string FactionSymbol { get; private set; }
        [JsonProperty("type")] public string Type { get; private set; }
        [JsonProperty("terms")] public Terms Terms { get; private set; }
        [JsonProperty("accepted")] public bool Accepted { get; private set; }
        [JsonProperty("fulfilled")] public bool Fulfilled { get; private set; }

        [JsonProperty("expiration")]
        [Obsolete("Deprecated in favor of deadlineToAccept")]
        public DateTime Expiration { get; private set; }

        [JsonProperty("deadlineToAccept")] public DateTime DeadlineToAccept { get; private set; }
    }

    public class Terms
    {
        [JsonProperty("deadline")] public DateTime Deadline { get; private set; }
        [JsonProperty("payment")] public Payment Payment { get; private set; }
        [JsonProperty("deliver")] public Deliverable[] Deliver { get; private set; }
    }

    public class Payment
    {
        [JsonProperty("onAccepted")] public int OnAccepted { get; private set; }
        [JsonProperty("onFulfilled")] public int OnFulfilled { get; private set; }
    }

    public class Deliverable
    {
        [JsonProperty("tradeSymbol")] public string TradeSymbol { get; private set; }
        [JsonProperty("destinationSymbol")] public string DestinationSymbol { get; private set; }
        [JsonProperty("unitsRequired")] public int UnitsRequired { get; private set; }
        [JsonProperty("unitsFulfilled")] public int UnitsFulfilled { get; private set; }
    }
}