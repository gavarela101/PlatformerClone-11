using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadly : MonoBehaviour
{
    //checks for physical collisions with a player
    private void OnCollisionEnter(Collision collision)
    {
        //check if colliding object was the player 
        if (collision.gameObject.GetComponent<Player>())
        {
            //player loses a life
            collision.gameObject.GetComponent<Player>().LoseLife();
        }
    }

    //checks for overlaps with the player
    private void OnTriggerEnter(Collider other)
    {
        //check if colliding object was the player 
        if (other.gameObject.GetComponent<Player>())
        {
            //player loses a life
            other.gameObject.GetComponent<Player>().LoseLife();
        }
    }

    //Subtracts enemy health when shot by player
    public void LoseHealth()
    {
        //have Enemy lose a life 
        Health--;

        //check if Enemy has zero health 
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
