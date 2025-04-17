using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/*
 * Jayden Saelee Chao
 * Last Updated: 4/16/2025
 * Controls player movement, jumping
 */

public class Player : MonoBehaviour
{
    public float Speed = 1f;
    public float jumpForce = 9f;
    public int maxHealth = 99;
    public int health = 99;

    private new Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

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
    if (Input.GetKeyDown(KeyCode.W) && OnGround() || Input.GetKeyDown(KeyCode.UpArrow) && OnGround())
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool OnGround()
    {
        bool onGround = false;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
        {
         onGround = true;
        }

        return onGround;
    }
}
