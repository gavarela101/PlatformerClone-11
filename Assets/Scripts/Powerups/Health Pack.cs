using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Jayden Saelee Chao
 * Last Updated: 4/16/2025
 * Controls health pack and healing
 */

public class HealthPack : MonoBehaviour
{
    public int heal = 50;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            if (other.GetComponent<Player>().health < other.GetComponent<Player>().maxHealth)
            {
                other.GetComponent<Player>().health += heal;
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            if (other.GetComponent<Player>().health > other.GetComponent<Player>().maxHealth)
            {
                other.GetComponent<Player>().health = other.GetComponent<Player>().maxHealth;
            }
        }
    } 
}
