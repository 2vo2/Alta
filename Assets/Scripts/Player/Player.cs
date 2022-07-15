using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Transform _finishPosition;
    [SerializeField] private float _scaleFactor;

    private void OnEnable()
    {
        _playerInput.InputUpdate += Scaled;
        _playerInput.CanceledInput += Move;
    }

    private void OnDisable()
    {
        _playerInput.InputUpdate -= Scaled;
        _playerInput.CanceledInput -= Move;
    }

    private void Move()
    {
        transform.DOMove(_finishPosition.position, 1f);
    }

    private void Scaled()
    {
        transform.localScale = new Vector3(transform.localScale.x - _scaleFactor, transform.localScale.y - _scaleFactor, transform.localScale.z - _scaleFactor);
    }
}
