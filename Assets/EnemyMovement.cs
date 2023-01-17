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
    private Vector3 distance;
    public float minDist = 14.0f;
    public float enemySpeed = 3.0f;
    private bool movingRight;
    public float rayDist = 2.0f;

    private void Start()
    {
        Enemy = GetComponent<Rigidbody2D>();
        movingRight = true;
    }
    // Update is called once per frame
    void Update()
    {
        distance = Enemy.transform.position - Player.transform.position;
    }
    
    private void FixedUpdate()
    {
        if (inRange())
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
            // Patrol path movement
            RaycastHit2D groundCheck = Physics2D.Raycast(groundDetect.position, Vector2.down, rayDist);

            if (groundCheck.collider == false)
            {
                groundDetect.localPosition = new Vector3(-groundDetect.localPosition.x, 
                    groundDetect.localPosition.y, 
                    groundDetect.localPosition.z
                );
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

    public bool inRange()
    {
        return Mathf.Abs(distance.x) <= minDist && Math.Abs(distance.y) <= 2 && distance.y < 0;
    }
}