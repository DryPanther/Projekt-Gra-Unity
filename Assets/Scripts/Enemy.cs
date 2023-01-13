using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animate;
    public int maxHealth = 100;
    int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;

    }
    private void FixedUpdate() {    
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            animate.SetTrigger("Die");
            animate.SetFloat("Die1",1);

            Invoke("Die", 1f);

        }else{
            animate.SetTrigger("Hit");
        }
    }
    void Die()
    {
        gameObject.active = false;
        Debug.Log("Enemy died!");
        
    }
    
    
}
