using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float moveSpeed;
    public Rigidbody2D rb;

    private Vector2 moveDirection;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float xPos = transform.position.x;
        float yPos = transform.position.y;

        //rotates character depending on if she's aiming left/right
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        //checks to make sure character is not out of bounds
        xPos = Mathf.Clamp(xPos, -7.3f, 7.3f);
        yPos = Mathf.Clamp(yPos, -4f, 4f);

        transform.position = new Vector2(xPos, yPos);

        //calls move processinputs function
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
