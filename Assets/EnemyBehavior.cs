using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
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

    int StartingHealth()
    {
        int maxHealth;

        maxHealth = 5;

        return maxHealth;
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
            //currentHealth -= damage;

            //if (currentHealth <= 0)
           // {
           //  /   Die();
           //     nextDamageTime = Time.time + 1f / maxDamageRate;
           // }
        }
    }

    void Die () 
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().GainExp(25);
        currentState = States.dead;
    }
}
