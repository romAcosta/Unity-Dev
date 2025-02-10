using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class RollerController : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private Transform view;
    
    [SerializeField] float rayLength = 1;
    [SerializeField] LayerMask groundLayer;
    
    Rigidbody rb;
    Vector2 movementInput = Vector2.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementInput.x, 0, movementInput.y);
        movement = Quaternion.AngleAxis(view.rotation.eulerAngles.y,Vector3.up) * movement;
        rb.AddForce( movement * speed);
    }
    
    public void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
        
    }

    public void OnJump()
    {
        if(OnGround()) rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private bool OnGround()
    {
        return Physics.Raycast(transform.position, Vector3.down,  rayLength, groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Vector3.down * rayLength);
    }
}
