using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

// player inherits from BasicPlayer
public class Paramour : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D paraCollider;
    public SpriteRenderer drawn;
    protected Animator myAnimator;

    public Rigidbody2D playerRB;
    public Collider2D playerCollider;

    public bool isDamaged;
    public bool playerIsMoving;

    public float velocityX;
    public float slowSpeed;

    protected int hairpos;
    protected int storyArc;

    private string paramourName;
    
    // start
    void Start()
    {
        drawn = GetComponent<SpriteRenderer>();
        myAnimator = this.GetComponent<Animator>();
        hairpos = ParamourSelectedAttributes.LoveSelectedHairPos;

        rb = GetComponent<Rigidbody2D>();
        paraCollider = GetComponent<Collider2D>();
        
        velocityX = 0f;
        slowSpeed = 0.75f;

        // if the Player exists
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
            playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
            if (playerRB.velocity == Vector2.zero)
            {
                playerIsMoving = false;
            }
            else {
                playerIsMoving = true;
                velocityX = playerRB.velocity.x;
            }

            // ignore the collision between the Paramour and the Player
            Physics2D.IgnoreCollision(paraCollider, playerCollider);
        }
    }

    void Update()
    {
        if (playerIsMoving)
        {
            // Paramour moves with Player at a slower rate
            rb.velocity = playerRB.velocity * slowSpeed;
        }
        else
        {   // when Player is not moving   
            // goes from being the same speed as the Player to zero
            rb.velocity = Vector2.Lerp(new Vector2(velocityX, rb.velocity.y), new Vector2(0, rb.velocity.y), 2f);
            playerIsMoving = false;
        }

        if (playerRB.velocity.x > 0.5f)
        {
            playerIsMoving = true;
        }
    }

    IEnumerator TakeDamage()
    {
        //TODO: add the logic for the player flashing red

        isDamaged = true;

        //This yield return allows us to give the player invincibility frames
        yield return new WaitForSeconds(2f);
        isDamaged = false;
    }

    // walk to Player's side when Player is too far away
    void KeepWalking()
    {
        Vector2 setVelocity = new Vector2(2f, 0);
        Debug.Log("entered KeepWalking()");
        while (Vector2.Distance(playerRB.transform.position, rb.transform.position) > Mathf.Abs(1f))
        { rb.velocity = setVelocity; }
    }

    // getter-setter for Name
    public string Name
    { get; set; }
}
