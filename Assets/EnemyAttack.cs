using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.VersionControl;

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
    public float strength = 70.0f;
    public float minShootDist = 10f;
    private Vector2 distance;
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = enemy.position - player.position;
        if (enemy.GetComponent<EnemyMovement>().CanAttack() && Mathf.Abs(distance.x) >= minShootDist)
        {
            Shoot();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.layer == 7)
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Attack();
        }    
    }
    void Attack()
    {
        anim.SetFloat("RPos", distance.x);
        anim.SetTrigger("Attack");
    }

    void Shoot()
    {
        if (Time.time - lastShot < cooldown)
        {
            return;
        }
        lastShot = Time.time;

        anim.SetFloat("RPos", distance.x);
        anim.SetTrigger("Shoot");
    }

    void createProjectile()
    {
        Instantiate(projectile, firePoint.position, Quaternion.identity);
    }
}
