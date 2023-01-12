using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    public GameObject DialogPanel;
    public TextMeshProUGUI Dialog;
    public string[] dialogue;
    private int index;

    
   
    public float wordSpeed;
    public bool playerIsClose;

    // Update is called once per frame
    void Update()
    {

      
            if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
            {
                
                if (DialogPanel.activeInHierarchy)
                {
                    zeroText();
                    
                }
                else
                {
                    DialogPanel.SetActive(true);
                    StartCoroutine(Typing());
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Dialog.text == dialogue[index])
                {
                    NextLine();
                }
            }
            
        
    }


    public  void zeroText()
    {
        Dialog.text = "";
        index= 0;
        DialogPanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray()) 
        {
            Dialog.text += letter;
            yield return new WaitForSeconds(wordSpeed);        
        }
    }

    public void NextLine()
    {
      
        if (index < dialogue.Length-1)
        {
            
            index++;
            Dialog.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose= true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}
