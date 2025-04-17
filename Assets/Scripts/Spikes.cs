using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Gabriel Varela
 * updated 4/17/20
 * Handles all coding for the Flying enemy
*/

public class Spikes : MonoBehaviour
{
    public int damage = 100;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Player>().health -= damage;
        }
    }
}
