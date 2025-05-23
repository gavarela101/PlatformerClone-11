using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/*
 * Xabiel, Garcia
 * Last Updated 4/19/25
 * Handles the UI for health and lives
 */

public class UiManager : MonoBehaviour
{
    public Player player;
    public TMP_Text healthText;

    void Update()
    {
        healthText.text = "Health: " + player.health;
    }
}
