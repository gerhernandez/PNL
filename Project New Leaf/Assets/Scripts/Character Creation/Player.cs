using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player inherits from BasicPlayer
public class Player : BasicPlayer
{
    public HealthManager hm;

    public Rigidbody2D rb;
    public GetPlayerValues getPlayerValues;
    public SpriteRenderer drawn;

    public bool isDamaged;

    public bool boarActivated;
    public bool hawkActivated;
    public bool wolfActivated;
    public bool snakeActivated;

    protected Animator myAnimator;
    
    protected int hairpos;
    protected int storyArc;
    
    private string playeName;
    // Health and Mana from BasicPlayer
    // public Player()
    // {
    //     Health = 100;
    //     Mana = 100;
    // }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        
        // if(hairpos >= 0 && hairpos <= 10){
        //     myAnimator.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("Animation/shorthairPlayer.controller", typeof(RuntimeAnimatorController )));
        // }
        // else if (hairpos > 10 && hairpos <= 16){
        //     myAnimator.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("Animation/medhairPlayer.controller", typeof(RuntimeAnimatorController )));
        // }
        // else{
        //     myAnimator.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("Animation/longhairPlayer.controller", typeof(RuntimeAnimatorController )));
        // }
        // myAnimator.SetBool("isGrounded", true);
    }
    // start
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        drawn = GetComponent<SpriteRenderer>();
        myAnimator = this.GetComponent<Animator>();
        hairpos = PlayerSelectedAttributes.PlaySelectedHairPos; 
    }
    
    void Update(){
        // nothing so far in Player Update
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("tag: " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Damage" && !isDamaged)
        {
            isDamaged = true;

            // start coroutine
            StartCoroutine("TakeDamage");
        }
    }

    // coroutine for damage
    IEnumerator TakeDamage()
    {
        isDamaged = true;
        Debug.Log("Damage taken");
        yield return new WaitForSeconds(2f);
        isDamaged = false;
    }

    // getter-setter for Name
    public string Name
    { get; set; }
}
