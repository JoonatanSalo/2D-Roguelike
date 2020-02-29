using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisckScript : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 2;
    public Rigidbody2D rb;


    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        ObstacleScript obstacle = collision.collider.GetComponent<ObstacleScript>();
        if (obstacle != null)
        {
            obstacle.TakeDamage(damage);
        }

        CombatScript disc = collision.collider.GetComponent<CombatScript>();
        if (disc != null)
        {
            disc.catchDisc();
            Destroy(gameObject);
        }
    }
}
