using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    
    private Vector3 _finishPoint;
    private PlayerInput _playerInput;

    public event UnityAction<Bullet> TriggerBullet;

    private void Awake()
    {
        _playerInput = FindObjectOfType<PlayerInput>();
        _finishPoint = FindObjectOfType<FinishPoint>().transform.position;
        print(_finishPoint);
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
        if (other.TryGetComponent(out Obstacle obstacle))
        {
            TriggerBullet?.Invoke(this);
            print(1);
        }
    }

    public void Move()
    {
        transform.DOMove(_finishPoint, 2f);
    }
}