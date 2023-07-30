using System.Collections;
using _Project.Scripts.Requests;
using _Project.Scripts.Response;
using Newtonsoft.Json;
using SVT.Networking;
using SVT.Networking.Extensions;
using UnityEngine;

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
            var request = getStatus.CreateRequest();
            yield return request.SendWebRequest();
            print(request.downloadHandler.text);
        }

        public IEnumerator GetAgentInfo()
        {
            getAgentInfo.Headers["Authorization"] = $"Bearer {token}";
            var request = getAgentInfo.CreateRequest();
            yield return request.SendWebRequest();
            print(request.downloadHandler.text);
            var response = JsonConvert.DeserializeObject<GetAgentResponse>(request.downloadHandler.text);
            print(response.Agent.Symbol);
        }

        public IEnumerator PostRegisterAgent()
        {
            var agentRequestData = new RegisterAgentRequestData(symbol, faction);
            var request = registerAgent.CreateRequest(agentRequestData);
            yield return request.SendWebRequest();
            print(request.downloadHandler.text);
            var response = JsonConvert.DeserializeObject<RegisterAgentResponse>(request.downloadHandler.text);
            print(response.Data.Token);
        }
    }
}