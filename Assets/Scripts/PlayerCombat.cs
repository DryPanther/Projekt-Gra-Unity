using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attckPoint;
    private Rigidbody2D rb2D;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    private bool swing = true;
    private bool push = true;
    public int attackDamage = 40;
    public float attackRate = 2f;
    public float nextAttackTime = 0f;
    public int HitPoints;
    public int HP = 100;
    public float moveSpeed;
    private float moveHorizontal;
    private float moveVertical;
    private bool facingRight = true;

    // Update is called once per frame

    private void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        moveSpeed = 3f;
        HitPoints = HP;
    }
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
        // obracanie sie bohatera
        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));
        animator.SetFloat("Up", Mathf.Abs(moveVertical));

        if (moveHorizontal > 0 && !facingRight)
        {
            Flip();
        }
        if (moveHorizontal < 0 && facingRight)
        {
            Flip();
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            rb2D.transform.Translate(Vector2.right * moveHorizontal * Time.deltaTime * moveSpeed);

        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            rb2D.transform.Translate(Vector2.up * moveVertical * Time.deltaTime * moveSpeed);

        }
        //Sekcja odpowiedzialna za wykrywanie u�ycia myszki do ataku
        if (Time.time >= nextAttackTime)
        {

            if (Input.GetMouseButtonDown(0))
            {
                Swing();
                Invoke("Atak1", 0.4f);
            }
        }
        if (Time.time >= nextAttackTime)
        {

            if (Input.GetMouseButtonDown(1))
            {
                Push();
                Invoke("Atak2", 0.2f);
               
            }
        }
        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("Ej !");
        }
        //Otrzymywanie obra�e�
        if (Time.time >= nextAttackTime)
        {

            if (Input.GetKey(KeyCode.B))
            {


                nextAttackTime = Time.time + 1f / attackRate;
                GetHit(20);
                Debug.Log("Trafienie!");
                Debug.Log(HitPoints);

            }

        }

        if (HitPoints <= 0)
        {
            Trup();
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
    void Atak1()
    {
        nextAttackTime = Time.time + 1f / attackRate;
        Debug.Log("Atak 1");
        swing = true;

        swing = false;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attckPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Trafienie atakiem 1" + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
    void Atak2()
    {
        nextAttackTime = Time.time + 1f / attackRate;
        Debug.Log("Atak 2!");
        push = true;

        push = false;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attckPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Trafienie atakiem 2" + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage / 2);
        }
    }
    public void GetHit(int damage)
    {

        animator.SetTrigger("IsHit");
        Debug.Log("AAA!");
        HitPoints = HitPoints - damage;
    }
    void Flip()
    {
        facingRight = !facingRight;

        Vector2 currentScale = transform.localScale;
        currentScale.x *= -1;

        transform.localScale = currentScale;
    }
    void Trup()
    {
        Debug.Log("Trup.....");
        animator.SetTrigger("Dead");
        nextAttackTime = Time.time + 100f / attackRate;
        moveSpeed = 0f;

    }

    private void OnDrawGizmosSelected()
    {
        if (attckPoint == null)
            return;
        Gizmos.DrawWireSphere(attckPoint.position, attackRange);
    }
}
