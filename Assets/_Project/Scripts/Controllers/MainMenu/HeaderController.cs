using _Project.Scripts.Response;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.Controllers.MainMenu
{
    [RequireComponent(typeof(MainMenuController))]
    public class HeaderController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI resetDisplay;
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

        private void OnStatusReceived(GetStatusResponse status)
        {
            resetDisplay.text = $"Last Reset on {status.ResetDate}";
        }
    }
}