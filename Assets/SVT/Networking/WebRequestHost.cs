using UnityEngine;

namespace SVT.Networking
{
    [CreateAssetMenu(menuName = "Networking/Web Request Manager")]
    public class WebRequestHost : ScriptableObject
    {
        [field: SerializeField] public string HostName { get; private set; }
    }
}