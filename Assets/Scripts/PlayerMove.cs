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
        //gets mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //moving left and right
        float moveInputX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        rb.velocity = new Vector2(moveInputX * speed, rb.velocity.x); 


        //moving up and down
        float moveInputY = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;
        rb.velocity = new Vector2(rb.velocity.x, moveInputY * speed);

        //Animation for idle 
        if (moveInputX == 0)
        {
            anim.Play("idle");
        }

        //Animation for moving
        if (Mathf.Abs(moveInputX) > 0 || Mathf.Abs(moveInputY) > 0)
        {
            anim.Play("Run");
        }


    }
}
