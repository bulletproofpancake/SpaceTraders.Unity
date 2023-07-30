using _Project.Scripts.Response;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.Views.MainMenu
{
    public class ResetDisplayView : MainMenuView
    {
        [SerializeField] private TextMeshProUGUI resetDisplay;

        public override void OnStatusReceived(GetStatusResponse status)
        {
            resetDisplay.text = $"Last Reset on {status.ResetDate}";
        }
    }
}