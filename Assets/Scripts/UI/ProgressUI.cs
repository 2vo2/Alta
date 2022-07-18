using UnityEngine;

namespace UI
{
    public class ProgressUI : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _winUI;
        [SerializeField] private CanvasGroup _warningUI;
        [SerializeField] private CanvasGroup _loseUI;
        [SerializeField] private ProgressChecker _progressChecker;
        [SerializeField] private FinishPoint _finishPoint;

        private void OnEnable()
        {
            _finishPoint.Win += OnWinMove;
            _progressChecker.Warning += OnWarning;
            _progressChecker.Lose += OnLose;
        }


        private void OnDisable()
        {
            _finishPoint.Win -= OnWinMove;
            _progressChecker.Lose -= OnLose;
        }

        private void OnWinMove()
        {
            ShowProgressScreen(_warningUI, 0);
            ShowProgressScreen(_winUI, 1);
        }

        private void OnWarning()
        {
            ShowProgressScreen(_warningUI, 1);
        }

        private void OnLose()
        {
            ShowProgressScreen(_warningUI, 0);
            ShowProgressScreen(_loseUI, 1);
        }

        private void ShowProgressScreen(CanvasGroup canvasGroup, int alpha)
        {
            canvasGroup.alpha = alpha;
        }
    }
}