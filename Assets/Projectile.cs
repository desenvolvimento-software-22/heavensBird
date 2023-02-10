using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed;
    public int damageAmount = 1;
    private float timer;
    private GameObject player;
    private Rigidbody2D rb;
    Vector3 direction;

    //Variavel booliano para verificar se este projetil pertence ao boss
    public bool isBoss;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        direction = player.transform.position - transform.position;
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        
        if (isBoss == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, rot + 177);
        }
    }
    // Update is called once per frame
    private void Update()
    {
        rb.velocity = direction.normalized * projectileSpeed;
        timer += Time.deltaTime;
        if (timer > 12)
        {
            Destroy(gameObject);
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<playerhealth>().takeDamage(damageAmount);
        }
        Destroy(gameObject);
        
    }
}
