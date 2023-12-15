using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float speed = 0.35f;
    private CircleCollider2D hitbox;
    private RaycastHit2D[] hit = new RaycastHit2D[10];
    private bool selfDestruct = false;

    void Start()
    {
        hitbox = GetComponent<CircleCollider2D>();
    }

    void FixedUpdate()
    {
        transform.position += (transform.TransformDirection(Vector3.right)) * speed;
        if (transform.position.x > Mathf.Abs(15) || transform.position.y > Mathf.Abs(15))
        {
            Destroy(gameObject);
        } else {
            
        }
    }

    void Update() {
        hit = Physics2D.CircleCastAll(hitbox.bounds.center, hitbox.radius, transform.up, hitbox.radius); //checks all collisions
        for(int i = 0; i < hit.Length; i++) {
            if(hit[i].collider != null) {
                if(hit[i].collider.GetComponent<EnemyHealth>() != null) {
                    hit[i].collider.GetComponent<EnemyHealth>().ReceiveDamage();
                    selfDestruct = true;
                }
            }
        }
        if(selfDestruct) {
            Destroy(gameObject);
        }
    }
}
