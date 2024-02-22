using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Animator animator;

    public float speed;
    Rigidbody2D rigidbody2D;

    public bool vertical;

    public float movetime = 2;
    public float timer;
    int direction = 1;

    public int damageAmount;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = movetime;
            direction = -direction;

        }

        if(vertical)
        {
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
    }


    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else 
        {
            position.x = position.x + Time.deltaTime * speed * direction;
        }
        
        rigidbody2D.MovePosition(position);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject + " is attacked by the enemy");
        if (collision.tag == "Player")
        {
            RubyController player = collision.GetComponent<RubyController>();
            player.ChangeHP(damageAmount);
        }
    }
}


