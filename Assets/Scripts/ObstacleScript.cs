using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public int maxHealth = 4;
    int currentHealth;

    public float maxImpactRate = 2f;
    float nextImpactTime = 0f;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (Time.time >= nextImpactTime) 
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                DestroyPanel();
                nextImpactTime = Time.time + 1f / maxImpactRate;
            }
        }
    }

    void DestroyPanel()
    {
        Destroy(gameObject);
    }
}
