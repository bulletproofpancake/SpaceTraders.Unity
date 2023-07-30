using System;
using System.Collections;
using _Project.Scripts.Interfaces;
using _Project.Scripts.Response;
using _Project.Scripts.Views.MainMenu;
using Newtonsoft.Json;
using SVT.Networking;
using SVT.Networking.Extensions;
using UnityEngine;

namespace _Project.Scripts.Controllers
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private WebRequestInfo getStatusRequest;
        [SerializeField] private LoginView loginView;
        private GetStatusResponse _status;
        private ToggleMainMenuView[] _toggleViews;

        public GetStatusResponse Status
        {
            get => _status;
            set
            {
                _status = value;
                StatusReceived?.Invoke(value);
            }
        }

        private void Awake()
        {
            _toggleViews = FindObjectsOfType<ToggleMainMenuView>();
        }

        private void OnEnable()
        {
            foreach (var toggleView in _toggleViews)
            {
                toggleView.ViewEnabled += OnViewEnabled;
                toggleView.ViewDisabled += OnViewDisabled;
            }

            GetStatus();
        }

        private void OnDisable()
        {
            foreach (var toggleView in _toggleViews)
            {
                toggleView.ViewEnabled -= OnViewEnabled;
                toggleView.ViewDisabled -= OnViewDisabled;
            }
        }

        private void OnViewDisabled(IToggleView view)
        {
            loginView.EnableObject();
        }

        private void OnViewEnabled(IToggleView view)
        {
            foreach (var toggleView in _toggleViews)
            {
                if ((ToggleMainMenuView)view == toggleView) continue;
                toggleView.DisableObject();
            }

            loginView.DisableObject();
        }

        public event Action<GetStatusResponse> StatusReceived;

        public void GetStatus()
        {
            StartCoroutine(GetStatusRoutine());
        }

        public IEnumerator GetStatusRoutine()
        {
            var request = getStatusRequest.CreateRequest();
            yield return request.SendWebRequest();
            Status = JsonConvert.DeserializeObject<GetStatusResponse>(request.downloadHandler.text);
        }
    }
}