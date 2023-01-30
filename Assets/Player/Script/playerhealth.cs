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
    public Rigidbody2D rb2;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        anim = GetComponent<Animator>();
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
            anim.SetTrigger("death");
            Invoke ("ReloadLevel", 3f);
            OnCollisionEnter2D();
            }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(health <=0)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

     }
     void ReloadLevel()
     {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     }
}
        
        
        
       
        
    

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
