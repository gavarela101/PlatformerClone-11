using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Gabriel Varela
 * updated 4/12/20
 * Handles all coding for the Flying enemy
*/

public class Portal : MonoBehaviour
{
    public Transform portalExit;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = portalExit.position;
    }
}
