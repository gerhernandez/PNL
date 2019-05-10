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
    public float speed;

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
        speed = 2.5f;

        // if the Player exists
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
            playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();

            // ignore the collision between the Paramour and the Player
            Physics2D.IgnoreCollision(paraCollider, playerCollider);
        }
    }

    void Update()
    {
       
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(Vector2.Distance(transform.position, playerRB.transform.position)) > 1f)
        { transform.position = Vector2.MoveTowards(transform.position, playerRB.transform.position, speed * Time.deltaTime); }
    }
    IEnumerator TakeDamage()
    {
        isDamaged = true;

        //This yield return allows us to give the player invincibility frames
        yield return new WaitForSeconds(2f);
        isDamaged = false;
    }

    // getter-setter for Name
    public string Name
    { get; set; }
}
