using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private float timeBtwAttack = 0;
    private float startTimeBtwAttack;
    private float damage;

    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    public Animator animator;
    public moveToAttack mvAtt;

    void Start()
    {
        startTimeBtwAttack = GetComponent<Damage>().getTimeReload();
        damage = GetComponent<Damage>().getDamage();
        mvAtt = GetComponent<moveToAttack>();
        animator = GetComponent<Animator>();
    }

    public void FixedUpdate()
    {
        if (timeBtwAttack <= 0)
        {
            animator.SetBool("rest", false);
            if (mvAtt.isReached())
            {
                animator.SetBool("reached", true);
            }
            else
            {
                animator.SetBool("reached", false);
            }
            
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
            if (mvAtt.isReached())
            {
                animator.SetBool("reached", true);
            }
            else
            {
                animator.SetBool("reached", false);
            }
        }
    }

    public void hit()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Health>().setDamage(damage);
        }
        timeBtwAttack = startTimeBtwAttack;
        animator.SetBool("rest", true);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}