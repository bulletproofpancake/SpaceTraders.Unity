using System;
using _Project.Scripts.Controllers;
using _Project.Scripts.Interfaces;
using _Project.Scripts.Response;
using UnityEngine;

namespace _Project.Scripts.Views.MainMenu
{
    public abstract class MainMenuView : MonoBehaviour
    {
        private MainMenuController Controller { get; set; }

        private void Awake()
        {
            if (!Controller) Controller = FindObjectOfType<MainMenuController>();
        }

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

    public abstract class ToggleMainMenuView : MainMenuView, IToggleView
    {
        [field: SerializeField] public GameObject GameObject { get; private set; }

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

        public event Action<IToggleView> ViewEnabled, ViewDisabled;
    }
}