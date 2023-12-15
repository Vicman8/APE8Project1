using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    private bool movingUP = true;
    private bool movingDOWN = false;
    private Vector3 randCoords;
    private Vector3 targetCoords;
    private float explosTimer = 3f;
    private SpriteRenderer sprRend;
    private Animator anim;

    private DamageRaycast damageCirc;

    void Start()
    {
        sprRend = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();

        damageCirc = GetComponent<DamageRaycast>();
    }

    void Update()
    {
        if (movingUP)
        {
            transform.position += new Vector3(0, 10 * Time.deltaTime, 0);
        }
        if (movingDOWN)
        {
            transform.position += new Vector3(0, -10 * Time.deltaTime, 0);
        }
        if (transform.position.y >= 10 && movingUP)
        {
            movingUP = false;
            targetCoords = randomizeCoords(randCoords);
            transform.position = new Vector3(targetCoords.x, transform.position.y - .5f, 0);
            movingDOWN = true;
        }
        if (transform.position.y > targetCoords.y - .1f && transform.position.y <= targetCoords.y + .1f)
        {
            movingDOWN = false;
            movingUP = false;
            explosTimer -= Time.deltaTime;
            anim.Play("Grenade");

            
        }
        if(explosTimer <= 1) {
            damageCirc.HitboxCircle(transform.position, 2.25f);
        }
        if (explosTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
    private Vector3 randomizeCoords(Vector3 randCoords)
    {
        return randCoords = new Vector3(Random.Range(-6, 7), Random.Range(-3, 4), 0);
    }
}
