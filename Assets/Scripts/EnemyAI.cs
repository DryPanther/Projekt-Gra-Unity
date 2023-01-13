using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject Player;
    public float startingSpeed;
    private float speed;
    public float distance;
    public Animator animate;
    private bool facingRight = true;
    public float vision = 8;
    void Start()
    {
        startingSpeed = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, Player.transform.position);
        Vector2 direction = Player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (direction.x > 0 && !facingRight)
        {
            Flip();
        }
        if (direction.x < 0 && facingRight)
        {
            Flip();
        }

        if(distance < vision)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, speed * Time.deltaTime);
            speed = startingSpeed;
            animate.SetFloat("Speed", 1);
        }
        if (animate.GetFloat("Attack1") == 1 || animate.GetFloat("Die1") == 1 || distance > vision)
        {
            animate.SetFloat("Speed", 0);
            speed = 0;
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
