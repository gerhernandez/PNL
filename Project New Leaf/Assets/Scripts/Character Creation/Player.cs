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


    // Health and Mana from BasicPlayer
    public Player()
    {
        Health = 100;
        Mana = 100;
    }

    // start
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }

    void FixedUpdate()
    {
        Debug.Log("Grounded: " + Grounded);
        Move();
    }
    
    // move Player
    public void Move()
    {
        Debug.Log("Move");
        float h = Input.GetAxis("Horizontal");
        transform.position = transform.position + (new Vector3(h * 0.2f, 0, 0));

        if (Input.GetKey(KeyCode.Space) && Grounded)
        {
            Debug.Log("Space");
            transform.position = Vector3.Lerp(transform.position, transform.position + (new Vector3(0, 2f, 0)), 2f);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D exit");
        if (collision.gameObject.tag == "Ground")
        {
            Grounded = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("OnCollisionExit2D entered");
        if (collision.gameObject.tag == "Ground")
        {
            Grounded = false;
        }
    }

    // getter-setter for Name
    public string Name
    { get; set; }

    public bool Grounded
    { get; set; }
}
