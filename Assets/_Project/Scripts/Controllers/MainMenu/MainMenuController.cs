using System;
using System.Collections;
using _Project.Scripts.Response;
using Newtonsoft.Json;
using SVT.Networking;
using SVT.Networking.Extensions;
using UnityEngine;

namespace _Project.Scripts.Controllers.MainMenu
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private WebRequestInfo getStatusRequest;
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

        private void OnEnable()
        {
            GetStatus();
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