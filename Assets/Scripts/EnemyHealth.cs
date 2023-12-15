using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int hitpoints = 50;
    public bool defaultBehavior = true;


    public void ReceiveDamage() {
        hitpoints--;
        CheckThreshold();
    }

    public void ReceiveDamage(int damageAmount) {
        hitpoints -= damageAmount;
        CheckThreshold();
    }

    public void CheckThreshold() {
        if(defaultBehavior && (hitpoints <= 0)) {
            Death();
        }
    }

    public void Death() {
        //Destroy(gameObject);
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("Ending");
    }
}
