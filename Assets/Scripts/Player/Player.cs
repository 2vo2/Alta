using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private ProgressChecker _winChecker;
    [SerializeField] private FinishPoint _finishPoint;
    [SerializeField] private CanvasGroup _winUI;

    public event UnityAction Win;
    
    private void OnEnable()
    {
        _winChecker.PlayerMove += OnPlayerMove;
    }
    

    private void OnDisable()
    {
        _winChecker.PlayerMove -= OnPlayerMove;
    }

    private void OnPlayerMove()
    {
        transform.DOMove(_finishPoint.transform.position, 3f).OnComplete(() =>
        {
            _winUI.alpha = 1;
            Win?.Invoke();
            transform.DOKill(this);
            gameObject.SetActive(false);
        });
    }
}
