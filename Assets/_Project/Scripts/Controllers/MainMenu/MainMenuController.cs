using System;
using System.Collections;
using _Project.Scripts.Response;
using _Project.Scripts.Views.MainMenu;
using Newtonsoft.Json;
using SVT.Networking;
using SVT.Networking.Extensions;
using UnityEngine;

namespace _Project.Scripts.Controllers.MainMenu
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private WebRequestInfo getStatusRequest;
        [SerializeField] private ToggleMainMenuView[] toggleViews;
        private GetStatusResponse _status;

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
            if (toggleViews.Length == 0) toggleViews = FindObjectsOfType<ToggleMainMenuView>();
        }

        private void OnEnable()
        {
            foreach (var toggleView in toggleViews) toggleView.ViewEnabled += OnViewEnabled;

            GetStatus();
        }

        private void OnDisable()
        {
            foreach (var toggleView in toggleViews) toggleView.ViewEnabled -= OnViewEnabled;
        }

        private void OnViewEnabled(ToggleMainMenuView view)
        {
            foreach (var toggleView in toggleViews)
            {
                if (view == toggleView) continue;
                toggleView.DisableObject();
            }
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