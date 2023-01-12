using System;
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attckPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers; 
    private bool swing = true;
    private bool push = true;
    public int attackDamage = 40;
    public float attackRate = 2f;
    public float nextAttackTime = 0f;

    // Update is called once per frame

    private void Start()
    {
        Debug.Log("Hello");
    }
    void Update()
    {
        //Sekcja odpowiedzialna za wykrywanie u�ycia myszki do ataku
        if (Time.time >= nextAttackTime)
        {

            if (Input.GetMouseButtonDown(0))
            {
                
                nextAttackTime = Time.time + 1f / attackRate;
                Debug.Log("Ci�cie !");
                swing = true;
                Swing();
                swing = false;
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attckPoint.position, attackRange, enemyLayers);

                foreach (BoxCollider2D enemy in hitEnemies)
                {
                    Debug.Log("Trafienie silne " + enemy.name);
                    enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
                }
            }
        }
        if (Time.time >= nextAttackTime)
        {

            if (Input.GetMouseButtonDown(1))
            {

              
                nextAttackTime = Time.time + 1f / attackRate;
                Debug.Log("Pchni�cie !");
                push = true;
                Push();
                push = false;
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attckPoint.position, attackRange, enemyLayers);

                foreach (BoxCollider2D enemy in hitEnemies)
                {
                    Debug.Log("Trafienie s�abe " + enemy.name);
                    enemy.GetComponent<Enemy>().TakeDamage(attackDamage/2);
                }
            }
        }
        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("chamie !");
        }
   

    }
    void Swing()
    {
        animator.SetTrigger("Swing");
    }
    void Push()
    { 
        animator.SetTrigger("Push");
    }


 
    private void OnDrawGizmosSelected()
    {
        if (attckPoint == null)
            return;
        Gizmos.DrawWireSphere(attckPoint.position, attackRange);
    }
}
