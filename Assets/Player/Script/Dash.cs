using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour

{
    // Start is called before the first frame update
    [SerializeField]
    private Rigidbody2D rgdbd;
    [SerializeField]
    private float velocity;

    private bool isDashing;

    [SerializeField]
    private float dashDuration;
    private float contDash;
    private Direction direction;
    [SerializeField]
    private float dashCooldown;
    private float cooldown;

    private bool canDash;

    void Start()
    {
        this.isDashing = false;
        this.contDash = 0;
        this.cooldown = 0;
        this.canDash = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (this.isDashing) {
            this.contDash += Time.deltaTime;
            if (this.contDash >= this.dashDuration) {
                this.contDash = 0;
                this.isDashing = false;
            } 
            else {
                if (this.direction == Direction.Right){
                    this.rgdbd.velocity = new Vector2(this.velocity, 0);
                } 
                else {
                    this.rgdbd.velocity = new Vector2(-this.velocity, 0);
                }
            }
        }    
        else {
            if (!this.canDash) {
                this.dashCooldown += Time.deltaTime;
                if (this.dashCooldown >= this.cooldown) {
                    this.dashCooldown = 0;
                    this.canDash = true;
                }
            }
        } 
    }
    public bool DashUsado {
        get {
            return this.isDashing;
        }
    }
    public void Aplicate(Direction directionDash) {
        if (this.canDash) {
            this.direction = directionDash;
            this.isDashing = true;
            this.canDash = false;
        }
        

    }
}
