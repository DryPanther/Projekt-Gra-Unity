using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : Enemy
{

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player"){
            animate.SetTrigger("Attack");
            animate.SetFloat("Attack1",1);
            Invoke("Go", 0.7f);
        }
    }
    private void Go(){
            animate.SetFloat("Attack1",0);
    }
}
