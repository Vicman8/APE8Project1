using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private DamageRaycast damageBox;
    private int ranNum;
    private float runDelay = 0.3f;
    private float delayTime;
    // Start is called before the first frame update
    void Start()
    {
        damageBox = GetComponent<DamageRaycast>();
        ranNum = Random.Range(0,9);
        delayTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //meant to stagment hitbox checks to reduce lag
        if(Time.time-(ranNum/10f) >= delayTime+runDelay) {
            damageBox.HitboxRect(transform.position, new Vector2(1f,1f), 0f);
            delayTime = Time.time;
        }
    }
    public void SpikeClear()
    {
        Destroy(gameObject);
    }
}
