using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject myObject;
    public Animator animate;
    public int maxHealth = 100;
    int currentHealth;
    public string weapon;
    void Start()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {
        if (currentHealth <= 0 & animate.GetFloat("Die1") == 0)
        {
            animate.SetTrigger("Die");
            animate.SetFloat("Die1", 1);

            Invoke("Die", 1f);
        }
    }
    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            currentHealth -= damage;
            if (currentHealth > 0)
            {
                animate.SetTrigger("Hit");
            }
        }


    }
    void Die()
    {
        if(weapon != null){
            myObject.GetComponent<PlayerCombat>().activeWeapon = weapon;
        }
        this.gameObject.SetActive(false);
        Debug.Log("Enemy died!");

    }


}
