using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.CompilerServices;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D Enemy;
    public GameObject Player;
    private Vector2 distance;
    public float minimumDistance = 10.0f;
    public float enemySpeed = 3.0f;

    private void Start()
    {
        Enemy = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        distance.x = Enemy.position.x - Player.transform.position.x;
        distance.y = Enemy.position.y - Player.transform.position.y;
        
        
        if (Math.Abs(distance.x) <= minimumDistance && Math.Abs(distance.y) <= 2)
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
    }
}