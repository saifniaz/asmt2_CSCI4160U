using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public float health = 100;

    public void takeDamage(float amount) {
        health -= amount;
        if(health <= 0f) {
            Destroy(gameObject);
        }

    }
}
