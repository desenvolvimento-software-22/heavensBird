using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthEnemy : MonoBehaviour
{
    public float health, maxHealth = 3f;
    // Start is called before the first frame update
    void Start()
    {
        // Set enemy health to max health
        health = maxHealth;
    }

    // Procedimento simples para verificar se o inimigo tomou dano e diminuir a vida dele
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
