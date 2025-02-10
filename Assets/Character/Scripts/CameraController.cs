using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float sensitivity = 1;
    [SerializeField,Range(2,10)] float distance;
    
    InputAction lookAction;
    Vector2 lookInput;
    Vector3 rotation = Vector3.zero;
    
    void Start()
    {
        lookAction = InputSystem.actions.FindAction("Look");
        lookAction.performed += Look;
        lookAction.canceled += Look;
        
        Quaternion qrotation = Quaternion.LookRotation(target.position - transform.position);
        rotation.x = qrotation.eulerAngles.x;
        rotation.y = qrotation.eulerAngles.y;
        rotation.z = qrotation.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        rotation.x += lookInput.y * sensitivity;
        rotation.y += lookInput.x * sensitivity;
        
        rotation.x = Mathf.Clamp(rotation.x, 20, 80);
        
        Quaternion qrotation = Quaternion.Euler(rotation);
        transform.position = target.position + qrotation * (Vector3.back * distance);
        transform.rotation = qrotation;
    }

    void Look(InputAction.CallbackContext ctx)
    {
        lookInput = ctx.ReadValue<Vector2>();

        
    }
}
