using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Sprite profile;
    public string[] speechTxt;
    public string actorName;

    public LayerMask playerLayer;
    public float radious;

    private DialogueControl dc;
    private Animator anim;
    bool onRadious;
    private bool executar = true;

    private void Start()
    {
        dc = FindObjectOfType<DialogueControl>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Interact();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && onRadious && executar == true)
        {
            dc.Speech(profile, speechTxt, actorName);
            executar = false;
        }
        if(executar == false)
        {
            KnightDeath(); 
        }
    }

    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer);

        if(hit != null)
        {
            onRadious = true;
        }
        else
        {
            onRadious = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radious);
    }

    public void KnightDeath()
    {
            anim.SetTrigger("deathk");
            this.GetComponent<Dialogue>().enabled = false;
    }
}
