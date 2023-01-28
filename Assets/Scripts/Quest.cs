using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject myObject;
    public Collider2D[] range;
    public int enemyNumber;

    // Update is called once per frame
    private void Start() {
        foreach (Collider2D enemy in range)
        {
            enemyNumber++;
        }
    }
    void Update()
    {
        if (enemyNumber == 0)
        {
            myObject.GetComponent<NPC>().Quest = true;
        }else{
            myObject.GetComponent<NPC>().Quest = false;
        }
    }
    
}
