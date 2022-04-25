using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class threatsAttack : MonoBehaviour
{
    private float timeBtwAttack = 0;
    private float startTimeBtwAttack;
    private float damage;

    public Transform attackPos;
    public LayerMask enemyAnts;
    public float attackRange;
    threatMoveToAttack mvAtt;

    void Start()
    {
        startTimeBtwAttack = GetComponent<Damage>().getTimeReload();
        damage = GetComponent<Damage>().getDamage();
        mvAtt = GetComponent<threatMoveToAttack>();
    }

    void FixedUpdate()
    {
        if (timeBtwAttack <= 0)
        {
            if (mvAtt.isReached())
            {
                hit();
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    public void hit()
    {
        timeBtwAttack = startTimeBtwAttack;
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyAnts);
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].GetType() == typeof(CapsuleCollider2D))
            {
                enemies[i].GetComponent<Health>().setDamage(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
