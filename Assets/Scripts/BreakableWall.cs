using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    public int Health = 5;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {
            DoorHealth();
        }
    }

    private void DoorHealth()
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
