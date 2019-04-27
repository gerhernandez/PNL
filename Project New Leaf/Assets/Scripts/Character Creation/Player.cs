using UnityEngine;

// player inherits from BasicPlayer
public class Player : BasicPlayer
{
    public Rigidbody2D rb;

    private string name;

    public GetPlayerValues getPlayerValues;

    protected Animator myAnimator;

    protected int hairpos;

    protected int storyArc;

    public SpriteRenderer drawn;

    public bool isDamaged;

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
    
    // getter-setter for Name
    public string Name
    { get; set; }
}
