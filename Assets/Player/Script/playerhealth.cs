using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerhealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int health;

    public SpriteRenderer PlayerSr;
    public Player playerMovement;
    private Animator anim;
    public bool isAlive = true;

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
            }
     }
}
        
        
        
       
        
    

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
