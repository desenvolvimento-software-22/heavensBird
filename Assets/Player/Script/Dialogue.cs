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
    bool onRadious;
    private bool executar = true;

    public GameObject player;

    private void Start()
    {
        dc = FindObjectOfType<DialogueControl>();
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
            player.GetComponent<Player>().enabled = false;
            executar = false;
        }
        if(executar == false && dc.speechText.text == "")
        {
            player.GetComponent<Player>().enabled = true;
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

}