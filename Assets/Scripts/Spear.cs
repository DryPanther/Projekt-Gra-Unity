using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public bool pickSpear2;
    public GameObject spearSon;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
    
        animator.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           
            pickUP();
        }
    }
    public void pickUP()
    {
        pickSpear2 = true;
        gameObject.GetComponent("Spear");
        gameObject.SetActive(false);
        Debug.Log("Wlocznia znika");
        animator.SetBool("SpearPicked", true);
     
    }
}
