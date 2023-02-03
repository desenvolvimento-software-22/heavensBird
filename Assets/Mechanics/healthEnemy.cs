using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthEnemy : MonoBehaviour
{
    public float health, maxHealth = 3f;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        // Set enemy health to max health
        health = maxHealth;
        animator = GetComponent<Animator>();
    }

    // Procedimento simples para verificar se o inimigo tomou dano e diminuir a vida dele
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            animator.SetTrigger("isDead");
        }
        else 
        {
            animator.SetTrigger("takenDa");
        }

    }

    public void Death()
    {
        Destroy(gameObject);
    }

}
