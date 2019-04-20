using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player inherits from BasicPlayer
public class Player : BasicPlayer
{
    public Rigidbody2D rb;
    public bool grounded;
    private string name;

    protected Animator myAnimator;

    protected float movementSpeed;

    protected bool facingRight;

    protected int hairpos;

    public SpriteRenderer drawn;

    public float speed, h, hX, noInputTime;
    bool idle = false;

    // Health and Mana from BasicPlayer
    public Player()
    {
        Health = 100;
        Mana = 100;
    }

    // start
    void Start()
    {
        noInputTime = 0;
        speed = 0.25f;
        rb = GetComponent<Rigidbody2D>();
        drawn = GetComponent<SpriteRenderer>();
        myAnimator = this.GetComponent<Animator>();
        hairpos = PlayerSelectedAttributes.PlaySelectedHairPos;
        if(hairpos >= 0 && hairpos <= 10){
            myAnimator.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("Animation/shorthairPlayer.controller", typeof(RuntimeAnimatorController )));
        }
        else if (hairpos > 10 && hairpos <= 16){
            myAnimator.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("Animation/medhairPlayer.controller", typeof(RuntimeAnimatorController )));
        }
        else{
            myAnimator.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("Animation/longhairPlayer.controller", typeof(RuntimeAnimatorController )));
        }
        myAnimator.SetBool("isGrounded", true);
    }

    void FixedUpdate()
    {
        //Debug.Log("Grounded: " + Grounded);
        Move();
        // noInputTime++;
        // myAnimator.SetFloat("NoInput", noInputTime);
    }
    
    // move Player
    public void Move()
    {
        noInputTime = 0;
        myAnimator.SetFloat("NoInput", noInputTime);
        //Debug.Log("Move");
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {
            h = Input.GetAxis("Horizontal");
            myAnimator.SetFloat("speed", Mathf.Abs(h));
            transform.Translate(transform.right * h * speed);
        }

        if (Input.GetAxis("HorizontalX") > 0 || Input.GetAxis("HorizontalX") < 0)
        {
            hX = Input.GetAxis("HorizontalX");
            myAnimator.SetFloat("speed", Mathf.Abs(hX));
            transform.Translate(transform.right * hX * speed);
        }
        
        //myAnimator.SetFloat("speed", 0); 
         

        if (h < 0)
        {
            drawn.flipX = true;
        }
        else if (h > 0)
        {
            drawn.flipX = false;
        }

         if ((Input.GetButtonDown("ButtonA") || Input.GetKeyDown(KeyCode.Space)) && Grounded)
        {
            rb.AddForce(transform.up * 6, ForceMode2D.Impulse);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D exit");
        if (collision.gameObject.tag == "Ground")
        {
            Grounded = true;
            myAnimator.SetBool("isGrounded", true);
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("OnCollisionExit2D entered");
        if (collision.gameObject.tag == "Ground")
        {
            Grounded = false;
            myAnimator.SetBool("isGrounded", false);
        }
    }

    // getter-setter for Name
    public string Name
    { get; set; }

    public bool Grounded
    { get; set; }
}
