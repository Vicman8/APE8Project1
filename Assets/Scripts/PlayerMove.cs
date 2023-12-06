using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    private Animator anim;
    private SpriteRenderer sprRend;
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject gun;

    [SerializeField] Sprite up;
    [SerializeField] Sprite down;
    [SerializeField] Sprite horiz;

    public PlayerLose plHealth;


    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprRend = GetComponent<SpriteRenderer>();
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
            //anim.Play("Idle");
        }


        //Animation for moving
        if (Mathf.Abs(moveInputX) > 0 || Mathf.Abs(moveInputY) > 0)
        {
            if (!(mousePos.y > transform.position.y + 2) && !(mousePos.y < transform.position.y - 2))
            {
                anim.Play("Run");
            }
            else if (mousePos.y > transform.position.y + 2)
            {
                anim.Play("PlayerWalkingUp");
            }
            else if (mousePos.y < transform.position.y - 2)
            {
                anim.Play("PlayerWalkingDown");
            }
        }

        if (mousePos.y > transform.position.y + 1)
        {
            sprRend.sprite = up;
        }

        if (mousePos.y < transform.position.y - 1)
        {
            sprRend.sprite = down;
        }

        if (mousePos.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (mousePos.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }


        //flashing for when player is invulnerable
        if(plHealth.isInvul) {
            sprRend.enabled = !sprRend.enabled;
        } else {
            sprRend.enabled = true;
        }
    }
}
