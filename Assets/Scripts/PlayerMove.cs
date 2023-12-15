using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float moveSpeed = 5f;
    private Rigidbody2D rb;

    private Animator anim;
    private SpriteRenderer sprRend;
    [SerializeField] GameObject gun;

    [SerializeField] Sprite up;
    [SerializeField] Sprite down;
    [SerializeField] Sprite horiz;

    private Vector2 playerMove;

    public PlayerLose plHealth;
    public bool isRolling = false;
    private float rollDelay = -2f;
    private bool queRoll = false;


    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprRend = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if(Input.GetMouseButtonDown(1)) {
            queRoll = true;
        }
    }

    private void FixedUpdate()
    {
        //gets mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(Time.time >= rollDelay+1.25f && queRoll) { //if player initiates roll
            if(!plHealth.isInvul) {
                anim.Play("DodgeRoll");
                isRolling = true;
                queRoll = false;
                rollDelay = Time.time;
            } else {
                queRoll = false; //cancels activation of roll if player was hit
            }
        } else if(!isRolling) { //if player is not rolling

            //reworked movement code (read input)
            playerMove = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

            //Animation for idle 
            if (playerMove == Vector2.zero)
            {
                //anim.Play("Idle");
            }


            //Animation for moving
            if (Mathf.Abs(playerMove.x) > 0 || Mathf.Abs(playerMove.y) > 0)
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
        } else if(Time.time >= rollDelay+0.75f) { //if player finished roll
            isRolling = false;
        }
        rb.velocity = playerMove * moveSpeed; //player movement

        //flashing for when player is invulnerable
        if(plHealth.isInvul && !isRolling) {
            sprRend.enabled = !sprRend.enabled;
        } else {
            sprRend.enabled = true;
        }
    }
}
