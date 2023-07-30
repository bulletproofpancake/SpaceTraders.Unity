using System;
using SVT.Networking.Interfaces;

namespace SVT.Networking
{
    [Serializable]
    public abstract class WebRequestData : IWebRequest
    {
        public abstract string ToJson();
    }
}