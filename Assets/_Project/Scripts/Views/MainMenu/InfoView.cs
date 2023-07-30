using System;
using _Project.Scripts.Response;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.Views.MainMenu
{
    public class InfoView : ToggleMainMenuView
    {
        [SerializeField] private TextMeshProUGUI status, description, nextReset, frequency, version;

        public override void OnStatusReceived(GetStatusResponse response)
        {
            status.text = $"Status: {response.Status}";
            description.text = $"{response.Description}";
            nextReset.text = $"Next Reset: {DateTime.Parse(response.ServerReset.Next):d}";
            frequency.text = $"Reset Frequency: {response.ServerReset.Frequency}";
            version.text = $"Version {response.Version}";
        }
    }
}