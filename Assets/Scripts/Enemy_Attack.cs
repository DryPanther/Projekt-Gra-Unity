using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : Enemy
{
    public float nextAttackTime = 0f;
    public float attackRate = 0.5f;
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            animate.SetTrigger("Attack");
            animate.SetFloat("Attack1", 1);
            Invoke("Go", 0.7f);
        }
    }
    private void Go()
    {
        animate.SetFloat("Attack1", 0);
    }
    private void OnTriggerStay2D(Collider2D other)
    {

        if (Time.time >= nextAttackTime)
        {
            if (other.gameObject.tag == "Player")
            {
                nextAttackTime = Time.time + 1f / attackRate;

                StartCoroutine(Swing(other));

            }
        }
    }
    IEnumerator Swing(Collider2D other)
    {
        yield return new WaitForSeconds(0.6f);
        other.GetComponent<PlayerCombat>().GetHit(20);
    }

}
