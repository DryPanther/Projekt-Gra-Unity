using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animate;
    private Rigidbody2D rb2D;
    private float moveSpeed;
    private float moveHorizontal;
    private float moveVertical;
    private bool facingRight = true;
    //private bool isattack;
    //private bool strongattack;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        animate = gameObject.GetComponent<Animator>();
        moveSpeed = 3f;
   
    }



    // Update is called once per frame
    void Update()
    {

        // movement bohatera

        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");


        // obracanie sie bohatera
        animate.SetFloat("Speed", Mathf.Abs(moveHorizontal));
        animate.SetFloat("Up", Mathf.Abs(moveVertical));

        if (moveHorizontal > 0 && !facingRight)
        {
            Flip();
        }
         if (moveHorizontal < 0 && facingRight)
        {
            Flip();
        }

        // //Sekcja odpowiedzialna za wykrywanie u¿ycia myszki do ataku (Aktualnie przeniesiona do skryptu PlayerCombat)
        //if (Input.GetMouseButton(0))
        //{
        //    Debug.Log("Wykonano atak");
        //    isattack = true;
        //    Debug.Log(isattack);
            
        //    animate.SetBool("Attack", (isattack));
            
        //    isattack = false;
            
        //    Debug.Log(isattack);
            
        //} 
            
            
        //if (Input.GetMouseButton(1))
        //{
        //    Debug.Log("Wykonano silny atak!");
        //    strongattack = true;
        //    Debug.Log(strongattack);
           
        //    strongattack = false;
        //    Debug.Log(strongattack);
        //}
        //if (Input.GetMouseButton(2))
        //{
        //    Debug.Log("chamie !");
        //}
    
    }
    void FixedUpdate()
    {
        //if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        //{
        //    rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);

        //}
        //else if (moveVertical > 0.1f || moveVertical < -0.1f)
        //{
        //    rb2D.AddForce(new Vector2(0f, moveVertical * moveSpeed), ForceMode2D.Impulse);
        //}
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            rb2D.transform.Translate(Vector2.right * moveHorizontal * Time.deltaTime * moveSpeed);

        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            rb2D.transform.Translate(Vector2.up * moveVertical * Time.deltaTime * moveSpeed);
         
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
