using System.Collections.Generic;
using _Project.Scripts.Response;
using _Project.Scripts.Views.MainMenu;
using UnityEngine;

namespace _Project.Scripts.Controllers.MainMenu
{
    [RequireComponent(typeof(MainMenuController))]
    public class AnnouncementController : MonoBehaviour
    {
        [SerializeField] private AnnouncementView announcementViewPrefab;
        [SerializeField] private Transform announcementParent;

        private MainMenuController _controller;
        private readonly List<AnnouncementView> _currentViews = new();

        private void Awake()
        {
            _controller = GetComponent<MainMenuController>();
        }

        private void OnEnable()
        {
            _controller.StatusReceived += OnStatusReceived;
        }

        private void OnDisable()
        {
            _controller.StatusReceived -= OnStatusReceived;
        }

        private void OnStatusReceived(GetStatusResponse response)
        {
            if (_currentViews.Count > 0)
            {
                for (var i = _currentViews.Count - 1; i >= 0; i--)
                {
                    var view = _currentViews[i];
                    Destroy(view.gameObject);
                }

                _currentViews.Clear();
            }

            foreach (var announcement in response.Announcements)
            {
                var view = Instantiate(announcementViewPrefab, announcementParent);
                view.Init(announcement.Title, announcement.Body);
            }
        }
    }
}