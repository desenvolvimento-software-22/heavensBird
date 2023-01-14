using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.CompilerServices;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D Enemy;
    public GameObject Player;
    public Transform groundDetect;
    private Vector2 distance;
    public float minimumDistance = 10.0f;
    public float enemySpeed = 3.0f;
    private bool movingRight = true;
    public float rayDist = 2.0f;

    private void Start()
    {
        Enemy = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        distance.x = Enemy.position.x - Player.transform.position.x;
        distance.y = Enemy.position.y - Player.transform.position.y;
    }
    
    private void FixedUpdate()
    {
        if (Mathf.Abs(distance.x) <= minimumDistance && Math.Abs(distance.y) <= 2 && distance.y < 0)
        {
            // Move towards the player
            if (distance.x > 0)
            {
                Enemy.velocity = new Vector2(-enemySpeed, Enemy.velocity.y);
            }
            else
            {
                Enemy.velocity = new Vector2(enemySpeed, Enemy.velocity.y);
            }
        }
        else
        {
            RaycastHit2D groundCheck = Physics2D.Raycast(groundDetect.position, Vector2.down, rayDist);

            if (groundCheck.collider == false)
            {
                groundDetect.localPosition = new Vector3(-groundDetect.localPosition.x, groundDetect.localPosition.y, groundDetect.localPosition.z);
                movingRight = groundDetect.localPosition.x > 0;
            }

            if (movingRight)
            {
                Enemy.velocity = new Vector2(enemySpeed, Enemy.velocity.y);
            }
            else
            {
                Enemy.velocity = new Vector2(-enemySpeed, Enemy.velocity.y);
            }
        }
    }
}