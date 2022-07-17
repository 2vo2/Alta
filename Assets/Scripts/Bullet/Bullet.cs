using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;

    private PlayerInput _playerInput;

    public Rigidbody Rigidbody => _rigidbody;
    public event UnityAction<Bullet> TriggerBullet;
    public event UnityAction TouchObstacle;

    private void Awake()
    {
        _playerInput = FindObjectOfType<PlayerInput>();
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

        if (other.TryGetComponent(out Obstacle obstacle))
        {
            TouchObstacle?.Invoke();
            TriggerBullet?.Invoke(this);
        }
    }
    
    private void Move()
    {
        _rigidbody.velocity = Vector3.forward * _speed;
    }
}