using System.Collections;
using System.Collections.Generic;
// MineralScript.cs

using UnityEngine;

public class MineralScript : MonoBehaviour
{
    public string mineralType; // "Wood", "Stone", "Iron"
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Mine(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            // You may want to spawn resources here or trigger other events.
        }
    }
}
