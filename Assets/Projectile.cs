using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed;
    // Start is called before the first frame update


    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
