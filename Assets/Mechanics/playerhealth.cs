using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerhealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int health;

    public SpriteRenderer PlayerSr;
    public Player playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }
    public void takeDamage(int damage){

        health -= damage;
        if(health <= 0){
            PlayerSr.enabled = false;
            playerMovement.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
