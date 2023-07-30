using System.Text;
using UnityEngine.Networking;

namespace SVT.Networking.Extensions
{
    public static class WebRequestExtensions
    {
        // https://youtu.be/K9uVHI645Pk
        public static UnityWebRequest CreateRequest(this WebRequestInfo info, WebRequestData data = null)
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