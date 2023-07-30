using System;
using _Project.Scripts.Controllers.MainMenu;
using _Project.Scripts.Response;
using UnityEngine;

namespace _Project.Scripts.Views.MainMenu
{
    public abstract class MainMenuView : MonoBehaviour
    {
        [field: SerializeField] public MainMenuController Controller { get; private set; }

        protected virtual void OnEnable()
        {
            Controller.StatusReceived += OnStatusReceived;
        }

        protected virtual void OnDisable()
        {
            Controller.StatusReceived -= OnStatusReceived;
        }

        public abstract void OnStatusReceived(GetStatusResponse response);
    }

    public abstract class ToggleMainMenuView : MainMenuView
    {
        [field: SerializeField] public GameObject GameObject { get; private set; }
        public event Action<ToggleMainMenuView> ViewEnabled, ViewDisabled;

        public virtual void EnableObject()
        {
            GameObject.SetActive(true);
            ViewEnabled?.Invoke(this);
        }

        public virtual void DisableObject()
        {
            GameObject.SetActive(false);
            ViewDisabled?.Invoke(this);
        }
    }
}