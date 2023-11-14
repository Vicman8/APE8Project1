using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprRend;
    [SerializeField] Sprite altSprite;
    [SerializeField] float rotSpeed;
    [SerializeField] GameObject target;
    [SerializeField] private Transform spriteContainer;
    private float targetDist = 0;
    private Vector2 velocity = Vector2.zero;
    private float time = 0;
    private float timeToTarget = 0;
    private float gravity;
    private GameObject newTarget;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (time < timeToTarget)
        {
            transform.Translate(0, (velocity.y - (gravity * time)) * Time.deltaTime, velocity.x * Time.deltaTime);
            time += Time.deltaTime;
        }
        else
        {
            sprRend.sprite = altSprite;
        }
        sprRend.transform.eulerAngles += new Vector3(0, 0, rotSpeed);

        if (sprRend.sprite == altSprite)
        {
            rotSpeed = 0f;
            sprRend.transform.eulerAngles = new Vector3(0, 0, 0);
            Destroy(target);
        }
    }
    public void Throw(Vector2 startPos, Vector2 targetPos, float angle, float grav)
    {
        Debug.Log(targetPos);
        Debug.DrawLine(startPos, targetPos, Color.red, 5);
        gravity = grav;
        transform.position = startPos;

        GameObject newTarget = Instantiate(target, targetPos, Quaternion.identity);

        targetDist = Vector2.Distance(startPos, targetPos);

        float vel = targetDist / (Mathf.Sin(2 * angle * Mathf.Deg2Rad) / gravity);

        velocity.x = Mathf.Sqrt(vel) * Mathf.Cos(angle * Mathf.Deg2Rad);
        velocity.y = Mathf.Sqrt(vel) * Mathf.Sin(angle * Mathf.Deg2Rad);

        timeToTarget = targetDist / velocity.x;

        transform.rotation = Quaternion.LookRotation(targetPos - startPos);
    }
}
