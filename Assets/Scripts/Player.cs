using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
    void Update()
    {
        Jump();
    }
    private void Move()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.position += Vector3.left * Speed * Time.deltaTime;
        }
        else
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position += Vector3.right * Speed * Time.deltaTime;
        }
    }

    private void Jump()
    {
    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) && OnGround())
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.position += Vector3.up * Speed * Time.deltaTime;
        }
    }

    private bool OnGround()
    {
        bool onGround = false;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.2f))
        {
            onGround = true;
        }

        return onGround;
    }
}
