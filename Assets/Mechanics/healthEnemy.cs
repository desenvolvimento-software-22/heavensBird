using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthEnemy : MonoBehaviour
{
    public float health, maxHealth = 3f;
    private Rigidbody2D recuo;
    public float recuoVelocidade = 500f;
    private Vector2 knockback;
    // Start is called before the first frame update
    void Start()
    {
        // Set enemy health to max health
        health = maxHealth;
        recuo = GetComponent<Rigidbody2D>();
        knockback = new Vector2( -100f, 0);
    }

    // Procedimento simples para verificar se o inimigo tomou dano e diminuir a vida dele
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        else 
        {
            Debug.Log(knockback.x);
            Debug.Log(knockback.y);
            recuo.AddForce( knockback, ForceMode2D.Impulse);
        }
    }
}
