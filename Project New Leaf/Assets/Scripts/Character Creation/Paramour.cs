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

    public LayerMask groundLayer;
    
    private Vector2 position;
    private Vector2 direction;

    public bool paraGrounded;
    public bool isDamaged;
    public bool isWalking;
    public bool facingRight;

    public float lastX;

    public float velocityX;
    public float speed;

    protected int hairpos;
    protected int storyArc;
    
    private string paramourName;
    private float distance;

    // start
    void Start()
    {
        drawn = GetComponent<SpriteRenderer>();
        myAnimator = this.GetComponent<Animator>();
        hairpos = ParamourSelectedAttributes.LoveSelectedHairPos;

        rb = GetComponent<Rigidbody2D>();
        paraCollider = GetComponent<Collider2D>();

        // distance of RayCollider
        distance = 0.5f;

        // speed of Paramour
        speed = 2.5f;

        // if the Player exists
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
            playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();

            // ignore the collision between the Paramour and the Player
            Physics2D.IgnoreCollision(paraCollider, playerCollider);
        }

        // initialize lastX with Paramour's last horizontal pos
        lastX = transform.position.x;
        facingRight = true;
    }

    void FixedUpdate()
    {
        CheckIfParamourIsGrounded();

        // flip paramour's sprite depending on which way they're walking
        if (transform.position.x > lastX || transform.position.x < lastX)
        {
            facingRight = transform.position.x > lastX ? true: false;
            isWalking = true;
            lastX = transform.position.x;
        }
        else if (transform.position.x == lastX)
        {
            isWalking = false;
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // if the movement is very slow
        if ((transform.position.x - lastX) >= -0.25f && (transform.position.x - lastX) <= 0.25f)
        { rb.velocity = new Vector2(0, rb.velocity.y); }
        
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

    public void CheckIfParamourIsGrounded()
    {
        position = transform.position - new Vector3(0f, 0.95f, 0f);
        Vector3 leftPos = transform.position + new Vector3(-0.25f, 0f, 0f);
        Vector3 rightPos = transform.position + new Vector3(0.25f, 0f, 0f);

        direction = Vector2.down;
        Vector2 leftDirection = new Vector2(-0.5f, -1f);
        Vector2 rightDirection = new Vector2(0.5f, -1f);
        
        // this number is for left and right direction length
        float angledDistance = 1.11f; 

        RaycastHit2D hit      = Physics2D.Raycast(position, direction, distance, groundLayer);
        RaycastHit2D leftHit  = Physics2D.Raycast(leftPos, leftDirection, angledDistance, groundLayer);
        RaycastHit2D rightHit = Physics2D.Raycast(rightPos, rightDirection, angledDistance, groundLayer);
        
        //Debug.DrawRay(position, direction, Color.blue);
        //Debug.DrawRay(leftPos, leftDirection, Color.red);
        //Debug.DrawRay(rightPos, rightDirection, Color.yellow);

        //Debug.Log("raycast hitting: " + hit.collider);
        //Debug.Log("leftRay hitting: " + leftHit.collider);
        //Debug.Log("rightRay hitting: " + rightHit.collider);

        if (hit.collider != null)
        { paraGrounded = true; }
        else
        { paraGrounded = false; }

        if (leftHit.collider == null && rightHit.collider != null)
        {
            // translate right harder
            rb.gravityScale = 0.05f;
        }
        else if (rightHit.collider == null && leftHit.collider != null)
        {
            // translate left harder
            rb.gravityScale = 0.05f;
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    // getter-setter for Name
    public string Name
    { get; set; }
}
