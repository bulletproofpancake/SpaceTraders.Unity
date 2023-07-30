using System.Collections.Generic;
using _Project.Scripts.Response;
using _Project.Scripts.Views.MainMenu;
using UnityEngine;

namespace _Project.Scripts.Controllers.MainMenu
{
    [RequireComponent(typeof(MainMenuController))]
    public class LeaderboardController : MonoBehaviour
    {
        [SerializeField] private LeaderboardEntryView leaderboardEntryPrefab;
        [SerializeField] private Transform creditsParent, chartParent;
        private readonly List<LeaderboardEntryView> _chartsList = new();
        private MainMenuController _controller;
        private List<LeaderboardEntryView> _creditsList = new();

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
            GenerateCreditsViews(response.Leaderboards.MostCredits);
            GenerateChartsViews(response.Leaderboards.MostSubmittedCharts);
        }

        private void GenerateCreditsViews(MostCredit[] credits)
        {
            if (_creditsList.Count > 0)
            {
                for (var i = _creditsList.Count - 1; i >= 0; i--)
                {
                    var view = _creditsList[i];
                    Destroy(view.gameObject);
                }

                _creditsList.Clear();
            }

            foreach (var credit in credits)
            {
                var view = Instantiate(leaderboardEntryPrefab, creditsParent);
                view.Init(credit.AgentSymbol, credit.Credits);
                _creditsList.Add(view);
            }
        }

        private void GenerateChartsViews(MostSubmittedChart[] charts)
        {
            if (_chartsList.Count > 0)
            {
                for (var i = _chartsList.Count - 1; i >= 0; i--)
                {
                    var view = _chartsList[i];
                    Destroy(view.gameObject);
                }

                _chartsList.Clear();
            }

            foreach (var chart in charts)
            {
                var view = Instantiate(leaderboardEntryPrefab, chartParent);
                view.Init(chart.AgentSymbol, chart.ChartCount);
                _chartsList.Add(view);
            }
        }
    }
}