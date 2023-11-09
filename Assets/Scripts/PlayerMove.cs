using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    private Animator anim;

    [SerializeField] float moveSpeed;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 movement = Vector2.zero;

        //moving left and right
        float moveInputX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        rb.velocity = new Vector2(moveInputX * speed, rb.velocity.x); 


        //moving up and down
        float moveInputY = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;
        rb.velocity = new Vector2(rb.velocity.x, moveInputY * speed);

        //movement += (transform.right * moveInputX) + (transform.up * moveInputY);

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
            anim.SetBool("IsRunning", true);
        }
        else if (moveInputX > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
            anim.SetBool("IsRunning", true);
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
