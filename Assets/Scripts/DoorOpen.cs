using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public BarKeep BarKeep;
    public SceneChange SceneChange;
    [SerializeField] GameObject falseDoor;
    Animator anim;
    bool check = true;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        falseDoor.SetActive(true);
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BarKeep.BottlesThrown <= 10 && check)
        {
            gameObject.SetActive(true);
            falseDoor.SetActive(false);
            anim.Play("DoorOpen");
            check = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Debug.Log("collision");
            SceneChange.ToOutsideScene();
        }
    }
    public void doorLead()
    {
        anim.Play("DoorLead");
    }
}
