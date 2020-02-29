using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider HealthBar;

    int PlayerMaxHealth;
    int PlayerCurrentHealth;
    int PlayerVitality = 50;

    public float maxDamageRate = 2f;
    float nextDamageTime = 0f;

    void Start()
    {
        PlayerMaxHealth = PlayerVitality + GetComponent<PlayerStats>().Strength * 20;
        HealthBar.maxValue = PlayerMaxHealth;
        PlayerCurrentHealth = PlayerMaxHealth;
        HealthBar.value = PlayerCurrentHealth;
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {

        if (Time.time >= nextDamageTime)
        {
            PlayerCurrentHealth -= damage;
            HealthBar.value = PlayerCurrentHealth;

            if (PlayerCurrentHealth <= 0)
            {
                Die();
                nextDamageTime = Time.time + 1f / maxDamageRate;
            }
        }
    }
    void Die()
    {
        HealthBar.value = PlayerCurrentHealth;
        Destroy(gameObject);
    }
}
