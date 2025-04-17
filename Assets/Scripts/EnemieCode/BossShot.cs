using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Gabriel Varela
 * updated 4/17/20
 * Handles all coding for the Flying enemy
*/

public class BossShot : MonoBehaviour
{
    [Header("Projectile Variables")]
    public float speed;
    public bool goingLeft;
    public int damage = 20;

    // Update is called once per frame
    void Update()
    {
        if (goingLeft == true)
        {
            transform.position += speed * Vector3.left * Time.deltaTime;
        }
        else
        {
            transform.position += speed * Vector3.right * Time.deltaTime;
        }

        //destroys laser after set seconds
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            if (other.GetComponent<Player>().health >= 0)
            {
                other.GetComponent<Player>().health -= damage;
            }
        }
    }
}
