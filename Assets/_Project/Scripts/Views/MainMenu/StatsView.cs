using _Project.Scripts.Controllers.MainMenu;
using _Project.Scripts.Response;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.Views.MainMenu
{
    [RequireComponent(typeof(MainMenuController))]
    public class StatsView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI agents, ships, systems, waypoints;
        private MainMenuController _controller;

        private void Awake()
        {
            _controller = GetComponent<MainMenuController>();
        }

        private void OnEnable()
        {
            _controller.StatusReceived += OnStatusReceived;
        }

        private void OnDisable()
        {
            _controller.StatusReceived -= OnStatusReceived;
        }

        private void OnStatusReceived(GetStatusResponse response)
        {
            agents.text = $"Agents: {response.Stats.Agents}";
            ships.text = $"Ships: {response.Stats.Ships}";
            systems.text = $"Systems: {response.Stats.Systems}";
            waypoints.text = $"Waypoints: {response.Stats.Waypoints}";
        }
    }
}