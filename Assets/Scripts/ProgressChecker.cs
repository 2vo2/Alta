using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class ProgressChecker : MonoBehaviour
{
    [SerializeField] private Player _player;

    private float _radius;
    private Vector3 _origin;
    private Vector3 _direction;

    public event UnityAction Win;
    public event UnityAction Warning;
    public event UnityAction Lose;

    private void FixedUpdate()
    {
        SphereCastParameters();

        WinCheck();
        LoseCheck();
    }

    private void LoseCheck()
    {
        if (_player.transform.localScale.x <= 0.3f)
        {
            Warning?.Invoke();
            if (_player.transform.localScale.x <= 0.2f)
            {
                Lose?.Invoke();
            }
        }
    }

    private void WinCheck()
    {
        RaycastHit hit;
        if (Physics.SphereCast(_origin, _radius, _direction, out hit))
        {
            if (hit.collider.TryGetComponent(out FinishPoint finishPoint))
            {
                Win?.Invoke();
            }
        }
    }

    private void SphereCastParameters()
    {
        _radius = _player.transform.localScale.x / 2f;
        _origin = _player.transform.position;
        _direction = _player.transform.TransformDirection(Vector3.forward);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.forward, _radius);
    }
#endif
}
