using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    
    private Vector3 _finishPoint;
    private PlayerInput _playerInput;

    public Rigidbody Rigidbody => _rigidbody;
    public event UnityAction<Bullet> TriggerBullet;

    private void Awake()
    {
        _playerInput = FindObjectOfType<PlayerInput>();
        _finishPoint = FindObjectOfType<FinishPoint>().transform.position;
    }

    private void OnEnable()
    {
        _playerInput.CanceledInput += Move;
    }

    private void OnDisable()
    {
        _playerInput.CanceledInput -= Move;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FinishPoint finishPoint))
        {
            TriggerBullet?.Invoke(this);
        }
    }

    public void Move()
    {
        _rigidbody.velocity = Vector3.forward * _speed;
    }
}