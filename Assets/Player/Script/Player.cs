using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // essa variável serve para controlar a velocidade na qual o personagem se movimenta
    public float speed;
    public SpriteRenderer spriteRenderer;
    
    // essa variável serve para controlarmos a gravidade do personagem
    private Rigidbody2D rig;
    private Animator anim;
    
    // essa variável serve para controlarmos a força do pulo na própria Unity
    public float JumpForce;
    public bool isJumping;
    //
    [SerializeField]
    private Dash dash;

    private Direction direction;

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
       } else if (velocidade.x < 0) {
        //Esquerda
        anim.SetBool("run", true);
        this.spriteRenderer.flipX = true;
        this.direction = Direction.Left;
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
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isJumping = false;
            anim.SetBool("jump", false);
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
         if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("attack");
        }
    }
    private void DashAplic(){
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            this.dash.Aplicate(this.direction);

        }
    }
}
