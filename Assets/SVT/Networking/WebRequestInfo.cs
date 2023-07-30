using System;
using System.Collections.Generic;
using UnityEngine;

namespace SVT.Networking
{
    [CreateAssetMenu(menuName = "Networking/Web Request Info")]
    public class WebRequestInfo : ScriptableObject
    {
        [field: SerializeField] public WebRequestHost Host { get; private set; }
        [field: SerializeField] public string EndPoint { get; private set; }
        [field: SerializeField] public WebRequestType Type { get; private set; }

        [SerializeField] private WebRequestHeader[] headers;

        private readonly Dictionary<string, string> _headers = new();

        public Dictionary<string, string> Headers
        {
            get
            {
                if (_headers.Count != 0) return _headers;

                foreach (var header in headers)
                {
                    if (_headers.TryAdd(header.Name, header.Value)) continue;
                    Debug.LogError($"Failed to add {header.Name} to dictionary.", this);
                }


                return _headers;
            }
        }

        public Uri Uri => new($"{Host.HostName}/{EndPoint}");
    }
}