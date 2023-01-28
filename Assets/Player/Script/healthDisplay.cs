using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthDisplay : MonoBehaviour
{

    public int health;
    public int maxHealth;

    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;
    public playerhealth Playerhealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health = Playerhealth.health;
        maxHealth = Playerhealth.maxHealth;   
        for (int i = 0; i < hearts.Length; i++){ 
            if (i < health){
                hearts[i].sprite = fullHeart;
            }else{
                hearts[i].sprite = emptyHeart;
            }
            if ( i < maxHealth){
                hearts[i].enabled = true;
            
            }else{
                hearts[i].enabled = false;
            }
        }
    }
}
