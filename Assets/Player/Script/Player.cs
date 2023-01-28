using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // essa variável serve para controlar a velocidade na qual o personagem se movimenta
    public float speed;
    public SpriteRenderer spriteRenderer;
    
    //controlar audios
    public AudioSource jumpSound;
    public AudioSource attackSoundVoice;
    public AudioSource attackSoundSword;
    
    // essa variável serve para controlarmos a gravidade do personagem
    private Rigidbody2D rig;
    private Animator anim;
    
    // essa variável serve para controlarmos a força do pulo na própria Unity
    public float JumpForce;
    public bool isJumping;
    //
    [SerializeField]
    private Dash dash;

    // Variaveis de ataque da personagem
    private Direction direction;
    public Transform attackPoint;
    public Transform attackPoint_esquerda;
    private bool swordSide = true; 
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public float attackDamage = 1f;

    //Tempo de ataque
    public float attackRate = 2f;
    private float nextAttackTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        this.direction = Direction.Right;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.dash.DashUsado) {
            Move();
            Jump();
            Attack();
            DashAplic();
        }
    }

    void Move()
    {
       float horizontal = Input.GetAxis("Horizontal");
       Vector2 velocidade = this.rig.velocity;
       velocidade.x = horizontal * this.speed;
       this.rig.velocity = velocidade;
       
       if (velocidade.x > 0) {
        //Direita
        this.spriteRenderer.flipX = false;
        anim.SetBool("run", true);
        this.direction = Direction.Right;

        //Verificar para qual lado o personagem ataca
        swordSide = true;

       } else if (velocidade.x < 0) {
        //Esquerda
        anim.SetBool("run", true);
        this.spriteRenderer.flipX = true;
        this.direction = Direction.Left;

        //Verificar para qual lado o personagem ataca
        swordSide = false;

       } else if (velocidade.x == 0) {
        anim.SetBool("run", false);
       }
       
       
        /* Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
        
        if(Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("run", true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
            this.direction = Direction.Right;
        }

        if(Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("run", true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
            this.direction = Direction.Left;
        }
        
        if(Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("run", false);
        } */
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && !isJumping)
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            anim.SetBool("jump", true);
            jumpSound.Play();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }

        //Função temporária teste para a morte da personagem no void
        if(collision.gameObject.layer == 7)
        {
            Destroy(gameObject);
            //Debug.Log("Tocando o void.");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isJumping = true;
        }
    }
    void Attack()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                // Animação de ataque
                anim.SetTrigger("attack");
                attackSoundVoice.Play();
                attackSoundSword.Play();

                if (swordSide == true)
                {
                    // Detect enemies in range
                    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

                    // Damage enemies
                    foreach(Collider2D enemy in hitEnemies)
                    {
                        enemy.GetComponent<healthEnemy>().TakeDamage(attackDamage);

                    }
                }
                else
                {
                    // Detect enemies in range
                    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint_esquerda.position, attackRange, enemyLayers);

                    // Damage enemies
                    foreach(Collider2D enemy in hitEnemies)
                    {
                        enemy.GetComponent<healthEnemy>().TakeDamage(attackDamage);

                    }
                }

                nextAttackTime = Time.time + 1f/attackRate;
            }
        }
    }
    //metodo para aplicação do dash
    private void DashAplic(){
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            this.dash.Aplicate(this.direction);

        }
    }

    //Raio do dano do ataque
    void OnDrawGizmosSelected() 
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);    
    }

}