using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Jayden Saelee Chao
 * Last Updated: 4/16/2025
 * Controls health powerup
 */

public class HealthUp : MonoBehaviour
{
    public int AddHealth = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        { 
            other.GetComponent<Player>().maxHealth += AddHealth;

            other.GetComponent<Player>().health = other.GetComponent<Player>().maxHealth;

            Destroy(gameObject);
        }
    }
}
