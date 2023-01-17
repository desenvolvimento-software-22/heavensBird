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

    private const int ParticleVel = 5;
    private bool isDashing;

    [SerializeField]
    private float dashDuration;
    private float contDash;
    private Direction direction;
    
    [SerializeField]
    private float dashCooldown;
    private float contTimeB4Use;

    private bool canDash;
    [SerializeField]
    private Animator animator;
    
    [SerializeField]
    private ParticleSystem particles;
    private ParticleSystem.MainModule particleMainModule;
    private ParticleSystemRenderer particlesRenderer;

    void Start()
    {
        this.isDashing = false;
        this.contDash = 0;
        this.contTimeB4Use = 0;
        this.canDash = true;
        this.particles.Stop();
        this.particleMainModule = this.particles.main;
        this.particlesRenderer = this.particles.GetComponent<ParticleSystemRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (this.isDashing) {
            this.contDash += Time.deltaTime;
            if (this.contDash >= this.dashDuration) {
                this.contDash = 0;
                this.isDashing = false;
                this.animator.SetBool("dash", false);
                this.particles.Stop();
            } 
            else {
                if (this.direction == Direction.Right){
                    this.rgdbd.velocity = new Vector2(this.velocity, 0);
                    this.particleMainModule.startSpeed = ParticleVel;
                    this.particlesRenderer.flip = Vector3.zero; //(0,0,0)
                } 
                else {
                    this.rgdbd.velocity = new Vector2(-this.velocity, 0);
                    this.particleMainModule.startSpeed = -ParticleVel;
                    this.particlesRenderer.flip = Vector3.right; //(1,0,0)
                }
            }
        }    
        else {
            if (!this.canDash) {
                this.contTimeB4Use += Time.deltaTime;
                if (this.contTimeB4Use >= this.dashCooldown) {
                    this.contTimeB4Use = 0;
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
            this.animator.SetBool("dash", true);
            this.particles.Play();
        }
        

    }
}
