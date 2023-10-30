using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public float shotDelay;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = shotDelay;
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //rotates gun wherever she aim
        float div = (mousePos.y - transform.position.y) / (mousePos.x - transform.position.x);
        float gunAngle = (Mathf.Atan(div)) * (180 / Mathf.PI);

        if (mousePos.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, -180, -gunAngle);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, gunAngle);
        }
        
       
        //shoots
        Vector2 gunAim = mousePos - transform.position;
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (Input.GetButton("Fire1") && timer <= 0)
        {
            if (mousePos.x < transform.position.x)
            {
                Instantiate(bullet, transform.position, Quaternion.Euler(0, -180, -gunAngle));
                timer = shotDelay;
            }
            else
            {
                Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, gunAngle));
                timer = shotDelay;
            }
            Debug.DrawRay(transform.position, gunAim, Color.green, 5f);
        }
    }
}
