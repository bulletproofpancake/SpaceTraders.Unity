using System;
using UnityEngine;

namespace _Project.Scripts.Interfaces
{
    public interface IToggleView
    {
        public GameObject GameObject { get; }
        public event Action<IToggleView> ViewEnabled, ViewDisabled;
        public void EnableObject();
        public void DisableObject();
    }
}