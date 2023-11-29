using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    private CircleCollider2D hitbox;

    void Start()
    {
        hitbox = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        transform.position += (transform.TransformDirection(Vector3.right)) * speed * Time.deltaTime;
        if (transform.position.x > Mathf.Abs(15) || transform.position.y > Mathf.Abs(15))
        {
            Destroy(gameObject);
        }

        RaycastHit2D hit = Physics2D.CircleCast(hitbox.bounds.center, hitbox.radius, transform.up, hitbox.radius);
        if(hit.collider != null) {
            hit.collider.GetComponent<EnemyHealth>().ReceiveDamage();
            Destroy(gameObject);
        }
    }
}
