using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Level = 1;
    int maxHealth;
    int currentHealth;

    public float maxDamageRate = 2f;
    float nextDamageTime = 0f;

    void Start()
    {
        maxHealth = 100 + Level * 50;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage) {

        if (Time.time >= nextDamageTime) 
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Die();
                nextDamageTime = Time.time + 1f / maxDamageRate;
            }
        }
    }

    void Die() {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().GainExp(25);
        Destroy(gameObject);
    }
}
