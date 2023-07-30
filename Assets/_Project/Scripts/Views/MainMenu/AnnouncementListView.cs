using System.Collections.Generic;
using _Project.Scripts.Response;
using UnityEngine;

namespace _Project.Scripts.Views.MainMenu
{
    public class AnnouncementListView : ToggleMainMenuView
    {
        [SerializeField] private AnnouncementView announcementViewPrefab;
        [SerializeField] private Transform announcementParent;
        private readonly List<AnnouncementView> _currentViews = new();

        public override void OnStatusReceived(GetStatusResponse response)
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
                _currentViews.Add(view);
            }
        }
    }
}