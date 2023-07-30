using System;
using _Project.Scripts.Response;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.Controllers.MainMenu
{
    [RequireComponent(typeof(MainMenuController))]
    public class InfoController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI status, description, nextReset, frequency, version;
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
            status.text = $"Status: {response.Status}";
            description.text = $"{response.Description}";
            nextReset.text = $"Next Reset: {DateTime.Parse(response.ServerReset.Next):d}";
            frequency.text = $"Reset Frequency: {response.ServerReset.Frequency}";
            version.text = $"Version {response.Version}";
        }
    }
}