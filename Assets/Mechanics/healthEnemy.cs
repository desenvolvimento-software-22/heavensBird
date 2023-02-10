using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            this.GetComponent<EnemyDamage>().enabled = false;
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

    IEnumerator BossDeath()
    {
        this.GetComponent<AudioSource>().enabled = false;
        yield return new WaitForSeconds(1);

        GameObject canvas = GameObject.Find("Canvas");
        GameObject child = canvas.transform.GetChild(0).gameObject;
        child.SetActive(true);

        yield return new WaitForSeconds(3);
        child.SetActive(false);
        SceneManager.LoadScene("Creditos", LoadSceneMode.Additive);

        Destroy(gameObject);
        yield return null;
    }
}
