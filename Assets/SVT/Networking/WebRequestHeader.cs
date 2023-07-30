using System;
using UnityEngine;

namespace SVT.Networking
{
    [Serializable]
    public class WebRequestHeader
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Value { get; private set; }
    }
}