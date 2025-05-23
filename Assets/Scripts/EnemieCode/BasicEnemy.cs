using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;
using UnityEngine.SceneManagement;
/*
 * Gabriel Varela
 * updated 4/9/20
 * Handles all coding for the basic enemy
*/

public class BasicEnemy : MonoBehaviour
{
    public GameObject LeftPoint;
    public GameObject RightPoint;
    public int Speed;
    public bool GoingLeft;
    public int Health = 1;
    public int damage = 15;

    private Vector3 leftPos;
    private Vector3 rightPos;

    // Start is called before the first frame update
    void Start()
    {
        leftPos = LeftPoint.transform.position;
        rightPos = RightPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //hanles enemy movement
    private void Move()
    {
        if (GoingLeft)
        {
            if (transform.position.x <= leftPos.x)
            {
                GoingLeft = false;
            }
            else
            {
                //moves the enemy to the left
                transform.position += Vector3.left * Time.deltaTime * Speed;
            }
        }
        else
        { 
            if (transform.position.x >= rightPos.x)
            {
                GoingLeft = true;
            }
            else
            {
                //moves the enemy to the right
                transform.position += Vector3.right * Time.deltaTime * Speed;
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
