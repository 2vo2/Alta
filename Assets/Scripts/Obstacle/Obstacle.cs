using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material _detonationMaterial;
    [SerializeField] private float _delay;

    public void Detonation()
    {
        StartCoroutine(Detonate());
    }

    private IEnumerator Detonate()
    {
        _renderer.material = _detonationMaterial;
        
        yield return new WaitForSeconds(_delay);

        gameObject.SetActive(false);
    }
}
