using UnityEngine;

public class Scaler : MonoBehaviour, IScale
{
    [SerializeField] private float _scaleFactor;

    private PlayerInput _playerInput;
    
    private void Awake()
    {
        _playerInput = FindObjectOfType<PlayerInput>();
    }

    private void OnEnable()
    {
        _playerInput.InputUpdate += Scaled;
    }

    private void OnDisable()
    {
        _playerInput.InputUpdate -= Scaled;
    }

    public void Scaled()
    {
        transform.localScale = new Vector3(transform.localScale.x + _scaleFactor, transform.localScale.y + _scaleFactor, transform.localScale.z + _scaleFactor);
    }
}
