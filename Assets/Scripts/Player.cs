using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;
using UnityEngine.SceneManagement;
/*
 * Jayden Saelee Chao
 * Last Updated: 4/19/2025
 * Controls player movement, jumping
 */

public class Player : MonoBehaviour
{
    public float Speed = 1f;
    public float jumpForce = 11f;
    public int maxHealth = 99;
    public int health = 99;
    public float projectileSpeed = 5f;
    public float fireRate = 0.5f;
    public float killHeight = -6f;

    public GameObject LaserPre;
    public GameObject HeavyLaserPre;

    private Vector2 shootingDirection;
    private float nextFireTime = 0f;
    private float currentRotationY;
    private GameObject bullet;
    private new Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        currentRotationY = transform.rotation.y;
        bullet = LaserPre;
    }

    void FixedUpdate()
    {
        Move();
    }
    void Update()
    {
        Jump();
        Death();

        if (Time.time >= nextFireTime && Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();

            nextFireTime = Time.time + fireRate;
        }

        if (currentRotationY != transform.rotation.y)
        {
            currentRotationY = transform.rotation.y;
        }
    }
    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.position += Vector3.left * Speed * Time.deltaTime;
        }
        else
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position += Vector3.right * Speed * Time.deltaTime;
        }
    }

    private void Jump()
    {
    if (Input.GetKeyDown(KeyCode.W) && OnGround())
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void Death()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(2);
        }

        if (transform.position.y < killHeight)
        {
            SceneManager.LoadScene(2);
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

    public void Shoot()
    {
        if (currentRotationY == -10)
        {
            shootingDirection = -transform.right;
        }
        else
        {
            shootingDirection = transform.right;
        }

        GameObject projectile = Instantiate(bullet, transform.position, Quaternion.identity);
         
        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

        if (projectileRigidbody != null)
        {
            projectileRigidbody.AddForce(shootingDirection * projectileSpeed, ForceMode.Impulse);
        }
        else 
        {
            //null
        }
    }

    public void SwitchPrefabs()
    {
        bullet = HeavyLaserPre;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemies")
        {
         StartCoroutine(IFrames());
        } 
    } 

    IEnumerator IFrames()
    {
        Physics.IgnoreLayerCollision(6, 7, true);
        yield return new WaitForSeconds(5);
        Physics.IgnoreLayerCollision(6, 7, false);
    }
}
