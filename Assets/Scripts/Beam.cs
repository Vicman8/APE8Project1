using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    private float timer = 5f;
    
    private DamageRaycast damageLine;

    void Start()
    {
        damageLine = GetComponent<DamageRaycast>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, 100 * Time.deltaTime));

        damageLine.HitboxRect(transform.position, 50f, 2f, transform.eulerAngles.z);

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
