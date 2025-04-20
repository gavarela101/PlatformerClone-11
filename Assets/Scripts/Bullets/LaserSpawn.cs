using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Jayden Saelee Chao
 * Last Updated: 4/19/2025
 * Controls laser inputs
 */

public class LaserSpawn : MonoBehaviour
{ 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BasicEnemy>())
        {
            other.gameObject.GetComponent<BasicEnemy>().LoseHealth();
            Destroy(gameObject);
        } 
        else if (other.gameObject.GetComponent<FlyingEnemy>())
        {
            other.gameObject.GetComponent<FlyingEnemy>().LoseHealth();
            Destroy(gameObject);
        }
        else if (other.gameObject.GetComponent<BossEnemy>())
        {
            other.gameObject.GetComponent<BossEnemy>().LoseHealth();
            Destroy(gameObject);
        }
        else if (other.gameObject.GetComponent<BreakableWall>())
        {
            other.gameObject.GetComponent<BreakableWall>().DoorHealth();
            Destroy(gameObject);
        }
        else if (other.transform.parent != null && other.transform.parent.name == "Level#1")
        {
            Destroy(gameObject);
        }
        else if (other.transform.parent != null && other.transform.parent.name == "Level#2")
        {
            Destroy(gameObject);
        }
        else if (other.transform.parent != null && other.transform.parent.name == "Level#3")
        {
            Destroy(gameObject);
        }
    }

}
