using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBarScript healthbar;
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            TakeDamage(20);
       
        }
    }
    void TakeDamage(int Damage)
    {
        currentHealth -= Damage;
        healthbar.SetHealth(currentHealth);
        
    }
}
