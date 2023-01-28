using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{
    public bool pickSaber2;
    public GameObject saberSon;
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

            pickUPSaber();
        }
    }
    public void pickUPSaber()
    {
        pickSaber2 = true;
        gameObject.GetComponent("Saber");
        gameObject.SetActive(false);
        Debug.Log("Szabla znika");
        animator.SetBool("SaberPicked", true);

    }
}
