using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    private Rigidbody2D rb2D;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    private bool swing = true;
    private bool push = true;
    public int attackDamage = 40;
    public float attackRate = 2f;
    public float HitPoints;
    public float HP = 100;
    public float moveSpeed;
    private float moveHorizontal;
    private float moveVertical;
    private bool facingRight = true;
    private bool pickSpear;
    bool canAttack = true;
    public string activeWeapon;


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
        if (animator.GetFloat("Dead1") == 0)
        {
            switch (activeWeapon)
            {
                case "Sword":
                    if (Input.GetMouseButtonDown(0) && canAttack)
                    {
                        canAttack = false;
                        Swing();
                        Invoke("ResetAttack", 1f);
                        Invoke("Atak1", 0.4f);
                    }
                    if (Input.GetMouseButtonDown(1) && canAttack)
                    {
                        canAttack = false;
                        Push();
                        Invoke("ResetAttack", 1f);
                        Invoke("Atak2", 0.2f);

                    }
                    break;
                case "Spear":
                    pickUP();
                    if (Input.GetMouseButtonDown(0) && canAttack)
                    {
                        canAttack = false;
                        Swing();
                        Invoke("ResetAttack", 0.5f);
                        Invoke("Atak3", 0.4f);
                    }
                    break;

                default:
                    break;
            }



        }
        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("Ej !");
        }
        //Otrzymywanie obra�e�

        if (Input.GetKey(KeyCode.B))
        {


            GetHit(20);
            Debug.Log("Trafienie!");
            Debug.Log(HitPoints);

        }

        if (HitPoints <= 0)
        {
            Trup();
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spear"))
        {

            pickUP();
        }
    }
    public void pickUP()
    {
        pickSpear = true;

        Debug.Log("podniesiono wlocznie");
        animator.SetBool("SpearPicked", true);
        Debug.Log(pickSpear);
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
        Debug.Log("Atak 1");
        swing = true;

        swing = false;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Trafienie atakiem 1" + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage / 2);
        }
    }
    void Atak2()
    {
        Debug.Log("Atak 2!");
        push = true;

        push = false;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Trafienie atakiem 2" + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
    void Atak3()
    {
        Debug.Log("Atak 3!");
        push = true;

        push = false;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Trafienie atakiem 3" + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage / 2);
        }
    }
    public void GetHit(int damage)
    {


        if (HitPoints > 0 && damage > 0)
        {
            animator.SetTrigger("IsHit");
            Debug.Log("AAA!");
            HitPoints = HitPoints - damage;
        }
    }
    void Flip()
    {
        if (animator.GetFloat("Dead1") == 0)
        {
            facingRight = !facingRight;

            Vector2 currentScale = transform.localScale;
            currentScale.x *= -1;

            transform.localScale = currentScale;
        }
    }
    void Trup()
    {
        Debug.Log("Trup.....");
        animator.SetTrigger("Dead");
        moveSpeed = 0f;
        animator.SetFloat("Dead1", 1);

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }
    void ResetAttack()
    {
        canAttack = true;
    }


}