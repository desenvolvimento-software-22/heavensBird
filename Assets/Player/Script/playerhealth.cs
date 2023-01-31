using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerhealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int health;

    public SpriteRenderer PlayerSr;
    public Player playerMovement;
    private Animator anim;
    public bool isAlive = true;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
     }

     public void CooldownStart()
     {
         StartCoroutine(CooldownCoroutine());
     }
     IEnumerator CooldownCoroutine()
     {
         anim.SetBool("damage", true);
         yield return new WaitForSeconds(0.2f);
         anim.SetBool("damage", false);
     }
     public void takeDamage(int damage){

         health -= damage;
            StartCoroutine(CooldownCoroutine()); 
            
            if(health <= 0)
            {
            isAlive = false;
            anim.SetBool("death", true);
            rb.bodyType = RigidbodyType2D.Static;
            this.GetComponent<Player>().enabled=false;
            Invoke ("LoadGameOver", 2f);
            }
     }
     void LoadGameOver()
     {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
     }
}
        
