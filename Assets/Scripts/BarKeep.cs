using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarKeep : MonoBehaviour
{
    [SerializeField] Bottle[] bottle;
    Vector2 randCoords;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int bottleNum = Random.Range(0, bottle.Length);
            float randX = Random.Range(-3.97f, 1.04f);
            float randY = Random.Range(-1.28f, 2.98f);
            randCoords = new Vector2(randX, randY);

            Bottle newBottle = Instantiate(bottle[bottleNum], transform.position, Quaternion.identity);
            newBottle.Throw(transform.position, randCoords, Random.Range(60, 75), 10);

        }
    }
}
