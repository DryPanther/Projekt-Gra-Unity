using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public CircleCollider2D Circle;
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
    private void FixedUpdate() {
        if (target != null){
            step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
             moveHorizontal = target.position.x;
             if (Mathf.Abs(target.position.x-transform.position.x) > Circle.radius || Mathf.Abs(target.position.y-transform.position.y) > Circle.radius){
            animate.SetFloat("Speed", 1);
       }
        }
       
        
        if (moveHorizontal > 0 && !facingRight)
        {
            Flip();
        }
         if (moveHorizontal < 0 && facingRight)
        {
            Flip();
        }
        if(animate.GetFloat("Attack1") == 1){
            speed = 0;
        }
        else{
            speed = 1;
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
