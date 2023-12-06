using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLose : MonoBehaviour
{
    public int hitpoints = 1;
    public bool defaultBehavior = true;
    private static int invulDuration = 1;
    private float hitTime = -invulDuration;
    public bool isInvul = false;

    public void Update() {
        isInvul = (Time.time-hitTime < invulDuration); //checks if a second has passed after last getting hit
    }

    public void ReceiveDamage() {
        if(!isInvul) {
            hitpoints--;
            CheckThreshold();
        }
    }

    public void ReceiveDamage(int damageAmount) {
        if(!isInvul) {
            hitpoints -= damageAmount;
            CheckThreshold();
        }
    }

    public void CheckThreshold() {
        hitTime = Time.time;
        isInvul = true;
        if(defaultBehavior && hitpoints <= 0) {
            Death();
        }
    }

    public void Death() {
        //insert lose state here
    }
}
