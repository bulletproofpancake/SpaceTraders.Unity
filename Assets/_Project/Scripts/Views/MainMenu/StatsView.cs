using _Project.Scripts.Response;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.Views.MainMenu
{
    public class StatsView : ToggleMainMenuView
    {
        [SerializeField] private TextMeshProUGUI agents, ships, systems, waypoints;

        public override void OnStatusReceived(GetStatusResponse response)
        {
            agents.text = $"Agents: {response.Stats.Agents}";
            ships.text = $"Ships: {response.Stats.Ships}";
            systems.text = $"Systems: {response.Stats.Systems}";
            waypoints.text = $"Waypoints: {response.Stats.Waypoints}";
        }
    }
}