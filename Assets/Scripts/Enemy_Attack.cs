using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : Enemy
{
    bool canAttack = true;
    public float attackRate;
    public int startingDamage;
    public int damage;
    void start()
    {
        damage = startingDamage;
    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        damage = startingDamage;
    }
    private void Go()
    {
        animate.SetFloat("Attack1", 0);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (animate.GetFloat("Die1") == 0)
        {
            if (other.gameObject.tag == "Player")
            {
                if (canAttack)
                {
                    canAttack = false;
                    animate.SetTrigger("Attack");
                    animate.SetFloat("Attack1", 1);
                    Invoke("ResetAttack", attackRate);
                    Invoke("Go", 0.7f);
                    if (other.gameObject.tag == "Player")
                    {

                        StartCoroutine(Swing(other));

                    }
                }
            }
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        damage = 0;
    }
    IEnumerator Swing(Collider2D other)
    {
        yield return new WaitForSeconds(0.6f);
        other.GetComponent<PlayerCombat>().GetHit(damage);
    }
    void ResetAttack()
    {
        canAttack = true;
    }
}
