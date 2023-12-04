using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    private float timer = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, 100 * Time.deltaTime));
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
