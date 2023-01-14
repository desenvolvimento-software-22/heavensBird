using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    public Rigidbody2D player;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            if (transform.position.x > player.position.x)
        {
            anim.SetFloat("RPos", 1);
        }
        else
        {
            anim.SetFloat("RPos", -1);
        }
            Attack();
        }    
    }
    void Attack()
    {
        anim.SetTrigger("Attack");
    }
}
