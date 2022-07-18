using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] private Transform _door;
    [SerializeField] private Player _player;

    public event UnityAction Win;
    
    private void OnEnable()
    {
        _player.WinMove += OnWinMove;
    }

    private void OnDisable()
    {
        _player.WinMove -= OnWinMove;
        transform.DOKill(this);
    }

    private void OnWinMove()
    {
        _door.DORotate(new Vector3(0f, 90f, 0f), 1f).OnComplete(() =>
        {
            Win?.Invoke();
            _player.gameObject.SetActive(false);
        });
    }

}
