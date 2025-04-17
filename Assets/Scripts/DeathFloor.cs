using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Gabriel Varela
 * updated 4/17/20
 * Handles all coding for the Flying enemy
*/

public class DeathFloor : MonoBehaviour
{
    public int death = 200; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            other.GetComponent<Player>().health -= death;
        }
    }
}
