using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class ProgressChecker : MonoBehaviour
{
    [SerializeField] private Transform _player;
    
    private float _radius;
    private Vector3 _origin;
    private Vector3 _direction;

    public event UnityAction PlayerMove;

    private void FixedUpdate()
    {
        SphereCastParameters();

        Win();
    }

    private void Win()
    {
        RaycastHit hit;
        if (Physics.SphereCast(_origin, _radius, _direction, out hit))
        {
            if (hit.collider.TryGetComponent(out FinishPoint finishPoint))
            {
                PlayerMove?.Invoke();
            }
        }
    }

    private void SphereCastParameters()
    {
        _radius = _player.localScale.x;
        _origin = _player.position;
        _direction = _player.TransformDirection(Vector3.forward);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.forward, _radius);
    }
#endif
}
