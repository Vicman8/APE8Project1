using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class boss : MonoBehaviour
{
    public int ihealth;
    private int chealth;
    public TMP_Text mytext;

    [SerializeField] private GameObject beam;
    // Start is called before the first frame update
    void Start()
    {
        chealth = ihealth;
        mytext.text = "Boss Health: " + ihealth + " / " + ihealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (chealth <= 0)
        {
            Destroy(gameObject);
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
}
