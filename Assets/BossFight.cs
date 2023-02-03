using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossFight : MonoBehaviour
{
    private Rigidbody2D Boss;
    public GameObject Player;
    public Transform firePoint;
    public GameObject projectile;
    private bool BossAlive = true;
    public float JumpForce = 200f, BossVelocity = 3f;
    private Vector3 distance;
    //private int Jumps = 0;

    //Variáveis do Tempo de CooldDown do Pulo
    public float nextJumpTime = 0f;
    public float JumpCooldown = 2f;

    public float ShootCoolDown = 5f;
    private float lastShot;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        Boss = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BossAlive == true)
        {
            //if (FightStart() == true)
            //{
            
            FirstRotation();
            SecondRotation();
            //}
        }
        else
        {
            Debug.Log("O Boss Está Morto!");
        }
    }

    // Função para garantir que o boss só vai começar a se mover
    // quando o player estiver no campo de batalha
    private bool FightStart() 
    {
        // Se o player estiver dentro do campo delimitado para a batalha
        if (Player.transform.position.x >= 97)
        {
            return true;
        }
        //Caso ele não esteja
        return false;
    }

    // Primeiro turno do boss
    // Neste turno ele ficará pulando em direção ao player
    void FirstRotation()
    {
        distance = Boss.transform.position - Player.transform.position;

        BossVelocity = MathF.Abs(distance.x) * 0.7f;
        //Debug.Log(Time.time);

        if (Time.time >= nextJumpTime)
        {

            // Animação de pulo
            anim.SetTrigger("Jump");

            if (distance.x > 0f)
            {
                Boss.AddForce(Vector2.up * JumpForce + Vector2.left * BossVelocity, ForceMode2D.Impulse);
                //Debug.Log("Está adicionando força!");
            }
            else 
            {
                Boss.AddForce(Vector2.up * JumpForce + Vector2.right * BossVelocity, ForceMode2D.Impulse);
                //Debug.Log("Está adicionando força!");
            }

            nextJumpTime = Time.time + JumpCooldown;
        }
    }


    //Segundo turno do boss
    //Neste turno o boss irá parar e começará a lançar diversos projetéis
    void SecondRotation()
    {
       // Debug.Log("Está vindo aqui");
        if (Time.time - lastShot < ShootCoolDown)
        {
            return;
        }
        lastShot = Time.time;
        anim.SetFloat("RPos", distance.x);
        anim.SetTrigger("Shoot");
    }

    void createProjectile()
    {
        Instantiate(projectile, firePoint.position, Quaternion.identity);
    }
}
