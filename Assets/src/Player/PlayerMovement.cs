using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;

    private new Rigidbody2D rigidbody;

    private Vector2 moveDirection;
    private Vector2 movementVelocityVector;

    public void OnMove(InputAction.CallbackContext inputActionContext)
    {
        moveDirection = inputActionContext.ReadValue<Vector2>();
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        movementVelocityVector = new Vector2(
            moveDirection.x * movementSpeed, rigidbody.velocity.y);
    }

    private void Move()
    {
        rigidbody.velocity = movementVelocityVector;
    }
}
