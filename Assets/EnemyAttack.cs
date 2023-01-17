using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private Rigidbody2D enemy;
    public Rigidbody2D player;
    public Transform firePoint;
    public GameObject projectile;
    public float cooldown;
    private float lastShot;
    private float lastAttack;
    public float strength = 70.0f;

    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float difference = Mathf.Abs(player.position.x - enemy.position.x);
        if (enemy.GetComponent<EnemyMovement>().inRange() && difference >= 8f)
        {
            Shoot();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (Time.time - lastAttack < cooldown)
        {
            return;
        }
        lastAttack = Time.time;

        if (collision.gameObject.tag == "Player")
        {
            Attack();
        }    
    }
    void Attack()
    {
        float difference;
        if (enemy.position.x > player.position.x)
        {
            difference = -1;
        }
        else
        {
            difference = 1;
        }
            
        if (difference < 0)
        {
            anim.SetFloat("RPos", 1);
        }
        else
        {
            anim.SetFloat("RPos", -1);
        }
        anim.SetTrigger("Attack");
        player.AddForce(new Vector3(difference, 0, 0) * strength, ForceMode2D.Impulse);
    }

    void Shoot()
    {
        if (Time.time - lastShot < cooldown)
        {
            return;
        }
        lastShot = Time.time;
        anim.SetTrigger("Shoot");
        Instantiate(projectile, firePoint.position, Quaternion.identity);
    }
}