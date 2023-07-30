using Newtonsoft.Json;

namespace _Project.Scripts.Response
{
    public class GetStatusResponse
    {
        [JsonProperty("status")] public string Status { get; private set; }
        [JsonProperty("version")] public string Version { get; private set; }
        [JsonProperty("resetDate")] public string ResetDate { get; private set; }
        [JsonProperty("description")] public string Description { get; private set; }
        [JsonProperty("stats")] public Stats Stats { get; private set; }
        [JsonProperty("leaderboards")] public Leaderboard Leaderboards { get; private set; }
        [JsonProperty("serverResets")] public ServerReset ServerReset { get; private set; }
        [JsonProperty("announcements")] public Announcement[] Announcements { get; private set; }
        [JsonProperty("links")] public Link[] Links { get; private set; }
    }

    public class Stats
    {
        [JsonProperty("agents")] public int Agents { get; private set; }
        [JsonProperty("ships")] public int Ships { get; private set; }
        [JsonProperty("systems")] public int Systems { get; private set; }
        [JsonProperty("waypoints")] public int Waypoints { get; private set; }
    }

    public class Link
    {
        [JsonProperty("name")] public string Name { get; private set; }
        [JsonProperty("url")] public string Url { get; private set; }
    }

    public class Announcement
    {
        [JsonProperty("title")] public string Title { get; private set; }
        [JsonProperty("body")] public string Body { get; private set; }
    }

    public class Leaderboard
    {
        [JsonProperty("mostCredits")] public MostCredit[] MostCredits { get; private set; }
        [JsonProperty("mostSubmittedCharts")] public MostSubmittedChart[] MostSubmittedCharts { get; private set; }
    }

    public class MostCredit
    {
        [JsonProperty("agentSymbol")] public string AgentSymbol { get; private set; }
        [JsonProperty("credits")] public int Credits { get; private set; }
    }

    public class MostSubmittedChart
    {
        [JsonProperty("agentSymbol")] public string AgentSymbol { get; private set; }
        [JsonProperty("chartCount")] public int ChartCount { get; private set; }
    }

    public class ServerReset
    {
        [JsonProperty("next")] public string Next { get; private set; }
        [JsonProperty("frequency")] public string Frequency { get; private set; }
    }
}