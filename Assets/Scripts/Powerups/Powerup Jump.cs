using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Jayden Saelee Chao
 * Last Updated: 4/16/2025
 * Controls jumping powerup
 */

public class PowerupJump : MonoBehaviour
{
    public float jumpUp = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            other.GetComponent<Player>().jumpForce += jumpUp;

            Destroy(gameObject);
        }
    }
} 
