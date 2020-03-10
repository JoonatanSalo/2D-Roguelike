using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public int level;
    public int currentHealth;
    public float baseDamage;

    public enum Classes
    {
        light,
        medium,
        heavy
    }

    Classes Class;

    public float maxDamageRate = 2f;
    float nextDamageTime = 0f;

    public enum States
    {
        notAlerted,
        alerted,
        inCombat,
        dead
    }

    States currentState;

    void Start()
    {
        currentState = States.notAlerted;
        Class = Classes.light;
        currentHealth = SetStartingHealth();
        baseDamage = SetBaseDamage();
    }

    void Update()
    {
        switch (currentState)
        {
            case States.notAlerted:
                //idle roaming around. if player detected or alert  -- >> currentState = States.Alerted
                break;

            case States.alerted:
                //go to target with pathfinding
                break;

            case States.inCombat:
                //fight loop, do combat stuff
                break;

            case States.dead:
                //be dead
                break;
        }
    }

    int SetStartingHealth()
    {
        int maxHealth = 0;
        int levelScaling = 0;

        if (Class == Classes.light)
        {
            maxHealth = 90;
            levelScaling = 10;
        }
        if (Class == Classes.medium)
        {
            maxHealth = 135;
            levelScaling = 15;
        }
        if (Class == Classes.heavy) 
        {
            maxHealth = 180;
            levelScaling = 20;
        }

        maxHealth += levelScaling * level;
        
        return maxHealth;
    }

    float SetBaseDamage()
    {
        float baseDamage = 0f;
        float levelScaling = 0f;

        if (Class == Classes.light)
        {
            baseDamage = 20f;
            levelScaling = 2f;
        }
        if (Class == Classes.medium)
        {
            baseDamage = 25f;
            levelScaling = 2.5f;
        }
        if (Class == Classes.heavy)
        {
            baseDamage = 30f;
            levelScaling = 3f;
        }

        baseDamage += levelScaling * level;

        return baseDamage;
    }

    void HighAttack ()
    {

    }

    void MidAttack()
    {

    }

    public void TakeDamage(int damage)
    {

        if (Time.time >= nextDamageTime)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Die();
            }

            nextDamageTime = Time.time + 1f / maxDamageRate;
        }

    }

    void Die () 
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().GainExp(25);
        currentState = States.dead;
    }
}
