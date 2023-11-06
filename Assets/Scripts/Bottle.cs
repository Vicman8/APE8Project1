using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprRend;
    [SerializeField] Sprite altSprite;
    [SerializeField] Sprite initialSprite;
    [SerializeField] float rotSpeed;
    private float targetDist = 0;
    private Vector2 velocity = Vector2.zero;
    private float time = 0;
    private float timeToTarget = 0;
    private float gravity;

    void Start()
    {
        sprRend = gameObject.GetComponent<SpriteRenderer>();
        sprRend.sprite = initialSprite;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0, 0, Time.deltaTime * rotSpeed);

        if (time < timeToTarget)
        {
            transform.Translate(0, (velocity.y - (gravity * time)) * Time.deltaTime, velocity.x * Time.deltaTime);
            time += Time.deltaTime;
        }
        else
        {
            sprRend.sprite = altSprite;
        }
    }
    public void Throw(Vector2 startPos, Vector2 targetPos, float angle, float grav)
    {
        gravity = grav;
        transform.position = startPos;

        targetDist = Vector2.Distance(startPos, targetPos);

        float vel = targetDist / (Mathf.Sin(2 * angle * Mathf.Deg2Rad) / gravity);

        velocity.x = Mathf.Sqrt(vel) * Mathf.Cos(angle * Mathf.Deg2Rad);
        velocity.y = Mathf.Sqrt(vel) * Mathf.Sin(angle * Mathf.Deg2Rad);

        timeToTarget = targetDist / velocity.x;

        transform.rotation = Quaternion.LookRotation(targetPos - startPos);
    }
}
