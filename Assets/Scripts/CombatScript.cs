using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatScript : MonoBehaviour
{
    public Animator animator;
    public LayerMask destrucktableLayers;

    public Transform meleePoint;
    public float attackRange = 0.5f;
    public int meleeDamage = 1;
    public float MeleeAttackRate = 2f;
    float nextAttackTime = 0f;

    void Start()
    {
       
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                animator.SetTrigger("AttackPunch");
                Melee();

                nextAttackTime = Time.time + 1f / MeleeAttackRate;
            }
        }
    }

    void Melee()
    {
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(meleePoint.position, attackRange, destrucktableLayers);

        foreach (Collider2D enemy in hitObjects)
        {
            enemy.GetComponent<EnemyBehavior>().TakeDamage(meleeDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (meleePoint == null)
            return;

        Gizmos.DrawWireSphere(meleePoint.position, attackRange);
    }
}
