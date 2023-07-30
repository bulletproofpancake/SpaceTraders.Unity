using TMPro;
using UnityEngine;

namespace _Project.Scripts.Views.MainMenu
{
    public class LeaderboardEntryView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI agentDisplay, countDisplay;

        public void Init(string agentSymbol, int count)
        {
            agentDisplay.text = agentSymbol;
            countDisplay.text = $"{count}";
        }
    }
}