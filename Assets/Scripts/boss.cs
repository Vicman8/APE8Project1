using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class boss : MonoBehaviour
{
    public int ihealth;
    private int chealth;
    public TMP_Text mytext;
    private bool attacking = false;
    private float timer = 6f;


    [SerializeField] private GameObject grenade;
    [SerializeField] private GameObject beam;
    
    void Start()
    {
        chealth = ihealth;
        mytext.text = "Boss Health: " + ihealth + " / " + ihealth;
    }

    
    void Update()
    {
        timer -= Time.deltaTime;
        if (chealth <= 0)
        {
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!attacking)
            {
                //shootAttack();
                grenadeShoot();
                grenadeShoot();
                grenadeShoot();
                attacking = true;
                timer = 6f;
            }
        }
        if (timer <= 0)
        {
            attacking = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            chealth -= 5;
            mytext.text = "Boss Health: " + chealth + " / " + ihealth;
        }
    }
    private void shootAttack()
    {
        int randDirection = Random.Range(0, 2);

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
        Instantiate(grenade, transform.position, Quaternion.identity);
    }
}
