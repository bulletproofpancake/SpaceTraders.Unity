using System;
using _Project.Scripts.Interfaces;
using UnityEngine;

namespace _Project.Scripts.Views.MainMenu
{
    public class LoginView : MonoBehaviour, IToggleView
    {
        [field: SerializeField] public GameObject GameObject { get; private set; }
        public event Action<IToggleView> ViewEnabled;
        public event Action<IToggleView> ViewDisabled;

        public void EnableObject()
        {
            GameObject.SetActive(true);
            ViewEnabled?.Invoke(this);
        }

        public void DisableObject()
        {
            GameObject.SetActive(false);
            ViewDisabled?.Invoke(this);
        }
    }
}