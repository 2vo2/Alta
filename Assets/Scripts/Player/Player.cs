using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private ProgressChecker _progressChecker;
    [SerializeField] private FinishPoint _finishPoint;

    public event UnityAction WinMove;

    private void OnEnable()
    {
        _progressChecker.Win += OnWin;
        _progressChecker.Lose += OnLose;
    }

    private void OnDisable()
    {
        _progressChecker.Win -= OnWin;
        _progressChecker.Lose -= OnLose;
        transform.DOKill(this);
    }

    private void OnLose()
    {
        gameObject.SetActive(false);
    }

    private void OnWin()
    {
        transform.DOMove(_finishPoint.transform.position, 3f).OnComplete(() =>
        {
            WinMove?.Invoke();
        });
    }
}
