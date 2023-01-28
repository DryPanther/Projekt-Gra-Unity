using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
 
    
    public GameObject swordSon;
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

            pickUPSword();
        }
    }
    public void pickUPSword()
    {
  
        gameObject.GetComponent("Sword");
        gameObject.SetActive(false);
        Debug.Log("Miecz znika");
        animator.SetBool("SwordPicked", true);

    }
}
