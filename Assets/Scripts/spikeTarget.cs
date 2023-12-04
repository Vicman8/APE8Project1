using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeTarget : MonoBehaviour
{
    [SerializeField] private boss Boss;
    // Start is called before the first frame update
    void Start()
    {
        Boss = FindObjectOfType<boss>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spikeAttack()
    {
        print("SPIKE");
        boss targeting = Boss.GetComponent<boss>();
        targeting.SpikeAttack();
    }
}
