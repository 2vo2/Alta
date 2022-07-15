using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public event UnityAction InputUpdate;
    public event UnityAction CanceledInput;
    
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            InputUpdate?.Invoke();
        }

        if (Input.GetMouseButtonUp(0))
        {
            CanceledInput?.Invoke();
        }
    }
}
