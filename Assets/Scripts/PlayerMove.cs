using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //moving left and right
        float moveInputX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInputX * speed, rb.velocity.y);

        //moving up and down
        float moveInputY = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(moveInputY * speed, rb.velocity.x);


        //Animation for moving to the left and right
        if (moveInputX == 0)
        {
            anim.SetBool("IsRunning", false);
        }
        else
        {
            anim.SetBool("IsRunning", true);
        }

        if (moveInputX < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        else if (moveInputX > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        //Animation for moving Up and Down
        if (moveInputY == 0)
        {
            anim.SetBool("IsRunning", false);
        }
        else
        {
            anim.SetBool("IsRunning", true);
        }

        if (moveInputY < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        else if (moveInputY > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }


    }
}
