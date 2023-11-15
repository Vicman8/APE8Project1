using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarKeep : MonoBehaviour
{
    [SerializeField] Bottle[] bottle;
    Vector2 randCoords;
    private bool throwing = false;
    [SerializeField] float throwDelay;
    private float timer;
    int bottlesThrown;
    [SerializeField] GameObject Door;
    public int BottlesThrown { get { return bottlesThrown; } }

    void Start()
    {
        timer = throwDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            throwing = true;
        }
        if (throwing && timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (throwing && timer <= 0 && bottlesThrown < 10)
        {
            bottlesThrown++;
            timer = throwDelay;
            ThrowBottle();
        }
        if (bottlesThrown == 10)
        {
            Door.SetActive(true);
            throwing = false;
        }
    }
    void ThrowBottle()
    {
        int bottleNum = Random.Range(0, bottle.Length);
        float randX = Random.Range(-3.97f, 1.04f);
        float randY = Random.Range(-1.28f, 2.98f);
        randCoords = new Vector2(randX, randY);

        Bottle newBottle = Instantiate(bottle[bottleNum], transform.position, Quaternion.identity);
        newBottle.Throw(transform.position, randCoords, Random.Range(60, 75), 10);
    }
}
