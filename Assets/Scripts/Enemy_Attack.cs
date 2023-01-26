using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : Enemy
{
    public float nextAttackTime = 0f;
    public float attackRate = 0.5f;
    public int damage;
    void start()
    {
        damage = 20;
    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        damage = 20;
    }
    private void Go()
    {
        animate.SetFloat("Attack1", 0);
    }
    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            if (Time.time >= nextAttackTime)
            {
                animate.SetTrigger("Attack");
                animate.SetFloat("Attack1", 1);
                Invoke("Go", 0.7f);
                if (other.gameObject.tag == "Player")
                {
                    nextAttackTime = Time.time + 1f / attackRate;

                    StartCoroutine(Swing(other));

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

}
