using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class boss : MonoBehaviour
{
    private int ihealth;
    private EnemyHealth chealth;
    public TMP_Text mytext;
    private bool attacking = false;
    private float timer = 6f;

    private int randNum;
    private GameObject[] spikes = new GameObject[20];
    private GameObject[] targets = new GameObject[20];
    private Animator anim;


    [SerializeField] private GameObject grenade;
    [SerializeField] private GameObject beam;
    [SerializeField] private GameObject spike;
    [SerializeField] private GameObject target;
    
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        chealth = GetComponent<EnemyHealth>();
        ihealth = chealth.hitpoints;
        mytext.text = "Boss Health: " + chealth.hitpoints + " / " + ihealth;
    }

    
    void Update()
    {
        mytext.text = "Boss Health: " + chealth.hitpoints + " / " + ihealth;

        timer -= Time.deltaTime;
        if (chealth.hitpoints <= 0)
        {
            Destroy(gameObject);
        }
        if (!attacking)
        {
            randNum = Random.Range(0, 3);
            if (randNum == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    grenadeShoot();
                }
            }

            else if (randNum == 1)
            {
                shootAttack();
            }
            else 
            {
                spikeTargets();
            }
            attacking = true;
            timer = 6f;
        }
        if (timer <= 0)
        {
            attacking = false;
        }
    }

    private void shootAttack()
    {
        int randDirection = Random.Range(0, 2);
        anim.Play("cactusSpin");

        if (randDirection == 0)
        {
            GameObject newBeam = Instantiate(beam, transform.position, Quaternion.Euler(0, 0, -90));
        }
        else
        {
            GameObject newBeam = Instantiate(beam, transform.position, Quaternion.Euler(0, 0, 90));
        }
    }
    private void grenadeShoot()
    {
        anim.Play("cactusGrenade");
        Instantiate(grenade, transform.position, Quaternion.Euler(0, 0, 180));
    }
    private void spikeTargets()
    {
        anim.Play("cactusGroundSpike");
        Vector3 randCoords;

        for (int i = 0; i < 20; i++)
        {
            randCoords = new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(-4.2f, 4.12f), 0f);
            targets[i] = Instantiate(target, randCoords, Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            targets[i].GetComponent<Animator>().Play("Target");
        }
    }
    public void SpikeAttack()
    {
        for (int i = 0; i < 20; i++)
        {
            spikes[i] = Instantiate(spike, targets[i].transform.position, Quaternion.identity);
            Destroy(targets[i]);
        }
    }
    
}
