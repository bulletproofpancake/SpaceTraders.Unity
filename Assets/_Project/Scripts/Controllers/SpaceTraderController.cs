using System.Collections;
using System.Text;
using _Project.Scripts.Requests;
using _Project.Scripts.Response;
using Newtonsoft.Json;
using SVT.Networking;
using UnityEngine;
using UnityEngine.Networking;

namespace _Project.Scripts.Controllers
{
    public class SpaceTraderController : MonoBehaviour
    {
        [SerializeField] private WebRequestInfo getStatus;
        [SerializeField] private WebRequestInfo registerAgent;
        [SerializeField] private WebRequestInfo getAgentInfo;
        [SerializeField] private string faction, symbol, token;

        private IEnumerator Start()
        {
            yield return GetAgentInfo();
        }

        public IEnumerator GetApiStatus()
        {
            var request = CreateRequest(getStatus);
            yield return request.SendWebRequest();
            print(request.downloadHandler.text);
        }

        public IEnumerator GetAgentInfo()
        {
            getAgentInfo.Headers["Authorization"] = $"Bearer {token}";
            var request = CreateRequest(getAgentInfo);
            yield return request.SendWebRequest();
            print(request.downloadHandler.text);
            var response = JsonConvert.DeserializeObject<GetAgentResponse>(request.downloadHandler.text);
            print(response.Agent.Symbol);
        }

        public IEnumerator PostRegisterAgent()
        {
            var req = new RegisterAgentRequest(symbol, faction);
            var request = CreateRequest(registerAgent, req);
            yield return request.SendWebRequest();
            print(request.downloadHandler.text);
            var response = JsonConvert.DeserializeObject<RegisterAgentResponse>(request.downloadHandler.text);
            print(response.Data.Token);
        }

        // https://youtu.be/K9uVHI645Pk
        private UnityWebRequest CreateRequest(WebRequestInfo info, WebRequestData data = null)
        {
            var request = new UnityWebRequest(info.Uri, info.Type.ToString());
            if (data != null)
            {
                var json = data.ToJson();
                var raw = Encoding.UTF8.GetBytes(json);
                request.uploadHandler = new UploadHandlerRaw(raw);
            }

            request.downloadHandler = new DownloadHandlerBuffer();
            foreach (var header in info.Headers) request.SetRequestHeader(header.Key, header.Value);
            return request;
        }
    }
}