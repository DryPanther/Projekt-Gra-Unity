using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject Player;
    public float speed;
    public float distance;
    public Animator animate;

    void Start()
    {
        speed = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, Player.transform.position);
        Vector2 direction = Player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        

        if (distance < 8)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, speed * Time.deltaTime);
            animate.SetFloat("Speed", 1);
        }
        if (distance > 8)
        {
            animate.SetFloat("Speed",0);
        }
    }
}
