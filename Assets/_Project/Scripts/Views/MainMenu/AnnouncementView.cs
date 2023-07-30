using TMPro;
using UnityEngine;

namespace _Project.Scripts.Views.MainMenu
{
    public class AnnouncementView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI titleDisplay, bodyDisplay;

        public void Init(string title, string body)
        {
            titleDisplay.text = title;
            bodyDisplay.text = body;
        }
    }
}