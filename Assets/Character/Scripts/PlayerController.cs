using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private Transform view;
    
    
    CharacterController controller;
    Vector2 movementInput = Vector2.zero;
    Vector3 velocity = Vector3.zero;
    InputAction moveAction;
    InputAction jumpAction;
    
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;
        
        jumpAction = InputSystem.actions.FindAction("Jump");
        jumpAction.performed += OnJump;
        jumpAction.canceled += OnJump;
        
        controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        Vector3 movement = new Vector3(movementInput.x, 0, movementInput.y);
        movement = Quaternion.AngleAxis(view.rotation.eulerAngles.y,Vector3.up) * movement;

        if (controller.isGrounded)
        {
            velocity.x = movement.x * speed;
            velocity.z = movement.z * speed;
        }
        
        
        velocity.y += Physics.gravity.y * Time.deltaTime; 
        controller.Move(velocity * Time.deltaTime);
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && controller.isGrounded)
        {
            velocity.y = jumpForce;
        }
    }

    

    
}
