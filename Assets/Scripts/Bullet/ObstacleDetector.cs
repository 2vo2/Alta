using UnityEditor;
using UnityEngine;

public class ObstacleDetector : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private int _layerID;
    [SerializeField] private Bullet _bullet;

    private void Update()
    {
        ScaledRadius();
    }

    private void OnEnable()
    {
        _bullet.TouchObstacle += Detected;
    }

    private void OnDisable()
    {
        _bullet.TouchObstacle -= Detected;
        _radius = 0.1f;
    }

    private void Detected()
    {
        var layerMask = 1 << _layerID;
        
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius, layerMask);
        foreach (var hitCollider in hitColliders)
        {
            hitCollider.gameObject.SetActive(false);
        }
    }

    private void ScaledRadius()
    {
        _radius += transform.localScale.x / 100f;
    }
    
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.up, _radius);
    }
#endif
}