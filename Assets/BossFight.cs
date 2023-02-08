using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossFight : MonoBehaviour
{
    private Rigidbody2D Boss;
    public GameObject Player;
    private Rigidbody2D rbPlayer;
    public Transform firePoint;
    public GameObject projectile;
    SpriteRenderer sr;
    private bool BossAlive = true;
    public float JumpForce = 200f, BossVelocity = 3f;
    private Vector3 distance;
    //private int Jumps = 0;

    //Variáveis do Tempo de CooldDown do Pulo
    public float nextJumpTime = 0f;
    public float JumpCooldown = 3f;

    public float ShootCoolDown = 5f;
    private float lastShot = 0f;
    private Animator anim;
    float difference;

    SpriteRenderer srBoss;

    bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        Boss = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rbPlayer = Player.GetComponent<Rigidbody2D>();

        nextJumpTime = Time.time + JumpCooldown;

        sr = projectile.GetComponent<SpriteRenderer>();

        srBoss = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<healthEnemy>().health <= 0)
        {
            Debug.Log("O Boss Está Morto!");
            BossAlive = false;
            this.enabled = false;
        }
        if (BossAlive)
        {
            //if (FightStart() == true)
            //{
            if (canJump)
            {
                FirstRotation();
            }
            SecondRotation();
            //}
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
        else 
        {
            anim.SetTrigger("startJump");
        }
    }


    //Segundo turno do boss
    //Neste turno o boss irá parar e começará a lançar diversos projetéis
    void SecondRotation()
    {
       // Debug.Log("Está vindo aqui");
        if (Time.time - lastShot < ShootCoolDown || Boss.velocity.y != 0f)
        {
            return;
        }
        canJump = false;
        sr.flipX = false;
        lastShot = Time.time;

        if (Boss.position.x > rbPlayer.position.x)
        {
            // Boss está na esquerda do player
            difference = -1;
        }
        else
        {
            // Boss está na direita do player
            difference = 1;
        }

        if (difference < 0)
        {
            sr.flipX = true;
            srBoss.flipX = true;
            //Debug.Log("Atirar na esquerda");
        }
        else
        {
            sr.flipX = false;
            //Debug.Log("Atirar na direita");
        }

        anim.SetTrigger("Shoot");

        anim.SetTrigger("startJump");
    }

    void createProjectile()
    {
        Instantiate(projectile, firePoint.position, Quaternion.identity);
    }

    void projectileTrueSide()
    {
        sr.flipX = false;
        srBoss.flipX = false;
        canJump = true;
    }

    // Funcao para trocar o Boss para a layer em q
    // ele n toma dano
    /*public void MudarLayer()
    {
        gameObject.layer = 10;
    }*/

    // Funcao para fazer o Boss voltar para a layer em
    // q ele n toma dano
    /*public void RetornarLayer()
    {
        gameObject.layer = 3;
        Debug.Log("Troca A layer de volta");
    }*/
}
