// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerMovement : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if(Input.GetKey("space"))
//         {
//             GetComponent<Rigidbody2D>().velocity = new Vector3(0, 7, 0);
//         }

//         if(Input.GetKey("right"))
//         {
//             GetComponent<Rigidbody2D>().velocity = new Vector3(5, 0, 0);
//         }

//         if(Input.GetKey("left"))
//         {
//             GetComponent<Rigidbody2D>().velocity = new Vector3(-5, 0, 0);
//         }
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public Animator anim;
    public float speed;  
    public float JumpForce;
    public bool isJumping;
    // private float dashAtual;
    // private bool canDash;
    // private bool isDashing;
    // public float duracaoDash;
    // public float dashSpeed;

    private Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.magnitude);

        transform.position = transform.position + movement * speed * Time.deltaTime;

        // Dash();
    }
    void Jump()
    {
        if(Input.GetButtonDown("Jump") && isJumping)
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);

        }
    }

//     void Dash()
//     {
//         if (Input.GetMouseButton(0) && canDash)
//         {
//             if (dashAtual <= 0)
//             {
//                 StopDash();
//             }
//             else
//             {
//                 isDashing = true;
//                 dashAtual -= Time.deltaTime;
//             }
//         }
//         if (Input.GetMouseButton(0))
//         {
//             isDashing = false;
//             canDash = true;
//             dashAtual = duracaoDash;
//         }
//     }
//     private void StopDash()
//     {
//         PlayerMov.velocity = Vector2.zero;
//         dashAtual = duracaoDash;
//         isDashing = false;
//         canDash = false;
//     }
}