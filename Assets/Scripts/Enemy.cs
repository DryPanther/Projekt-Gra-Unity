using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animate;
    public float speed;
    public float step;
    public float startingSpeed = 3f;
    private Transform target;
    public int maxHealth = 100;
    int currentHealth;
    private bool facingRight = true;
    private float moveHorizontal;
    void Start()
    {
        currentHealth = maxHealth;
        speed = startingSpeed;

    }
    private void Update() {
        if (target != null){
            step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
             moveHorizontal = target.position.x;
        }
       
        
        if (moveHorizontal > 0 && !facingRight)
        {
            Flip();
        }
         if (moveHorizontal < 0 && facingRight)
        {
            Flip();
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();

        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player"){
            target = other.transform;
            animate.SetFloat("Speed", 1);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player"){
            target = null;
            animate.SetFloat("Speed", 0);
        }
    }
    void Flip()
    {
        facingRight = !facingRight;

        Vector2 currentScale = transform.localScale;
        currentScale.x *= -1;

        transform.localScale = currentScale;
    }
}
