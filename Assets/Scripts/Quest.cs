using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject myObject;
    public int enemyNumber;

    // Update is called once per frame
    private void Start()
    {
        Vector2 boxSize = new Vector2(200, 200);
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, boxSize, 0);
        foreach (Collider2D collider in hitColliders)
        {
            if (collider.gameObject.tag == "Enemy")
            {
                enemyNumber++;
            }
        }
    }
    void Update()
    {
        if (enemyNumber == 0)
        {
            myObject.GetComponent<NPC>().Quest = true;
        }
        else
        {
            myObject.GetComponent<NPC>().Quest = false;
        }
    }

}
