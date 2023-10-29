using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float moveSpeed;
    public Rigidbody2D rb;

    private Vector2 moveDirection;

    //calls move processinputs function
    void Update()
    {
        ProcessInputs();
    }
    
    //calls move function
    void FixedUpdate()
    {
        Move();
    }

    //Moves the player up/down/left/right
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    //changes the speed of the player
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
