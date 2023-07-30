using System.Collections;
using System.Text;
using SVT.Networking;
using UnityEngine;
using UnityEngine.Networking;

namespace _Project.Scripts.Controllers
{
    public class SpaceTraderController : MonoBehaviour
    {
        [SerializeField] private WebRequestInfo getStatus;

        private IEnumerator Start()
        {
            yield return GetApiStatus();
        }

        public IEnumerator GetApiStatus()
        {
            var request = CreateRequest(getStatus);
            yield return request.SendWebRequest();
            print(request.downloadHandler.text);
        }

        // https://youtu.be/K9uVHI645Pk
        private UnityWebRequest CreateRequest(WebRequestInfo info, WebRequestData data = null)
        {
            var request = new UnityWebRequest(info.Uri, info.Type.ToString());
            if (data != null)
            {
                var raw = Encoding.UTF8.GetBytes(data.ToJson());
                request.uploadHandler = new UploadHandlerRaw(raw);
            }

            request.downloadHandler = new DownloadHandlerBuffer();
            foreach (var header in info.Headers) request.SetRequestHeader(header.Key, header.Value);
            return request;
        }
    }
}