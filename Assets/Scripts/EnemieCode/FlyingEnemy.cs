using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Gabriel Varela
 * updated 4/9/20
 * Handles all coding for the Flying enemy
*/

public class FlyingEnemy : MonoBehaviour
{
    public GameObject DownPoint;
    public GameObject UpPoint;
    public int Speed;
    public bool GoingDown;
    public int Health = 1;
    public int damage = 15;

    private Vector3 DownStart;
    private Vector3 UpStart;

    // Start is called before the first frame update
    void Start()
    {
        DownStart = DownPoint.transform.position;
        UpStart = UpPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //hanles enemy movement
    private void Move()
    {
        if (GoingDown)
        {
            if (transform.position.y <= DownStart.y)
            {
                GoingDown = false;
            }
            else
            {
                //moves the enemy down
                transform.position += Vector3.down * Time.deltaTime * Speed;
            }
        }
        else
        { 
            if (transform.position.y >= UpStart.y)
            {
                GoingDown = true;
            }
            else
            {
                //moves the enemy up
                transform.position += Vector3.up * Time.deltaTime * Speed;
            }
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
