using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatScript : MonoBehaviour
{
    public GameObject disckPrefab;

    public Transform meleePoint;
    public LayerMask destrucktableLayers;
    public Transform throwPoint;

    public float ThrowRate = 2f;
    float nextThrowTime = 0f;

    public float attackRange = 0.5f;
    public int meleeDamage = 1;
    public float MeleeAttackRate = 2f;
    float nextAttackTime = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Time.time >= nextThrowTime) 
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Throw();

                nextThrowTime = Time.time + 1f / ThrowRate;
            }
        }

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Melee();

                nextAttackTime = Time.time + 1f / MeleeAttackRate;
            }
        }
    }

    void Throw() 
    {
        Instantiate(disckPrefab, throwPoint.position, throwPoint.rotation);
    }

    void Melee()
    {
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(meleePoint.position, attackRange, destrucktableLayers);

        foreach (Collider2D enemy in hitObjects)
        {
            enemy.GetComponent<Enemy>().TakeDamage(meleeDamage);
        }
    }

    public void catchDisc()
    {
        nextThrowTime = Time.time;
    }

    private void OnDrawGizmosSelected()
    {
        if (meleePoint == null)
            return;

        Gizmos.DrawWireSphere(meleePoint.position, attackRange);
    }
}
