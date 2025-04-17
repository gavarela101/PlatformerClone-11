using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Jayden Saelee Chao
 * Last Updated: 4/16/2025
 * Controls bullet powerup
 */

public class PowerupBullets : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            Destroy(gameObject);
        }
    }
}
