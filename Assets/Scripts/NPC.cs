using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    public GameObject Player;
    public GameObject DialogPanel;
    public TextMeshProUGUI Dialog;
    public string[] dialogue;
    public string[] dialogue2;
    private int index;
    bool canTalk = true;
    public bool Quest;


    public float wordSpeed;
    public bool playerIsClose;

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.E) && playerIsClose && canTalk == true)
        {
            canTalk = false;
            Invoke("ResetTalk", 0.5f);
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
        if (Input.GetKeyDown(KeyCode.Space) && canTalk == true)
        {
            canTalk = false;
            Invoke("ResetTalk", 0.5f);
            if (Dialog.text == dialogue[index])
            {
                NextLine();
            }
        }


    }


    public void zeroText()
    {
        Dialog.text = "";
        index = 0;
        DialogPanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        if (Quest == false)
        {
            foreach (char letter in dialogue[index].ToCharArray())
            {
                Dialog.text += letter;
                yield return new WaitForSeconds(wordSpeed);
            }
        }
        if (Quest == true)
        {
            foreach (char letter in dialogue2[index].ToCharArray())
            {
                Player.GetComponent<PlayerCombat>().HitPoints = Player.GetComponent<PlayerCombat>().HP;
                Dialog.text += letter;
                yield return new WaitForSeconds(wordSpeed);
            }
        }
    }

    public void NextLine()
    {

        if (index < dialogue.Length - 1)
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
            playerIsClose = true;
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
    void ResetTalk()
    {
        canTalk = true;
    }
}
