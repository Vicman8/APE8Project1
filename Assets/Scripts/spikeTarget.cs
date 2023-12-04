using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeTarget : MonoBehaviour
{
    [SerializeField] private GameObject Boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spikeAttack()
    {
        boss targeting = Boss.GetComponent<boss>();
        targeting.SpikeAttack();
    }
}
