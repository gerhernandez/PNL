using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

// player inherits from BasicPlayer
public class Player : BasicPlayer
{
    [SerializeField] private HealthManager hm;
    [SerializeField] private Move movement;

    public Rigidbody2D rb;
    public GetPlayerValues getPlayerValues;
    public SpriteRenderer drawn;

    public bool isDamaged;
    public int Health;
    public int Mana;

    [SerializeField] private static bool boarActivated;
    [SerializeField] private static bool hawkActivated;
    [SerializeField] private static bool wolfActivated;
    [SerializeField] private static bool snakeActivated;

    protected Animator myAnimator;
    
    protected int hairpos;
    protected int storyArc;
    
    private string playerName;

    private Vector2 currentCheckPoint;
    private const string FADE_SCREEN = "Fade";

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
        drawn = GetComponent<SpriteRenderer>();
        myAnimator = this.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        movement = this.GetComponent<Move>();
        hairpos = PlayerSelectedAttributes.PlaySelectedHairPos;
    }
    
    void Update(){
        // nothing so far in Player Update

        if (Input.GetKeyDown(KeyCode.U))
        {
            hm.updateHealthDisplay(-1);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (hm.attemptManaConsumption())
            {
                hm.updateManaDisplay(-1);
            } else
            {
                Debug.Log("Not enough Mana");
            }
        }

    }

    private void OnCollisionStay2D(Collider2D collision)
    {
        Debug.Log("tag: " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Damage" && !isDamaged)
        {
            //We tell our health manager that our player has taken damage
            hm.updateHealthDisplay(-1);
            StartCoroutine("TakeDamage");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CheckPoint")
        {
            Transform newCheckPoint = collision.gameObject.transform;
            Debug.Log("Triggered with " + collision.gameObject.name);
            currentCheckPoint = new Vector2(newCheckPoint.position.x, newCheckPoint.position.y);
        }
    }

    public IEnumerator PlayerDeathFadeScreen()
    {
        ToggleMovement();
        Flowchart.BroadcastFungusMessage(FADE_SCREEN);
        yield return new WaitForSeconds(1.3f);
        this.transform.position = currentCheckPoint;
        hm.resetCurrHealth();
        yield return new WaitForSeconds(1f);
        ToggleMovement();
    }

    IEnumerator TakeDamage()
    {
        //TODO: add the logic for the player flashing red

        isDamaged = true;

        //This yield return allows us to give the player invincibility frames
        yield return new WaitForSeconds(2f);
        isDamaged = false;
    }

    public void UpgradeStats()
    {
        hm.upgradeMaxHealth();
        hm.upgradeMaxMana();

        //Only if we don't have the snake power
        if (boarActivated && hawkActivated && !snakeActivated)
        {
            snakeActivated = true;
        }
        //Only if we don't have the hawk power
        else if (boarActivated && !hawkActivated && snakeActivated)
        {
            hawkActivated = true;
        }
        //Only if we don't have the boar power
        else if (!boarActivated && hawkActivated && snakeActivated)
        {
            boarActivated = true;
        }
        //If we only have the boar power
        else if (boarActivated && !hawkActivated && !snakeActivated)
        {
            randomPowerBewteenTwo(Random.Range(1, 2), hawkActivated, snakeActivated);
        }
        //If we only have the hawk power
        else if (!boarActivated && hawkActivated && !snakeActivated)
        {
            randomPowerBewteenTwo(Random.Range(1, 2), boarActivated, snakeActivated);
        }
        //If we only have the snake power
        else if (!boarActivated && !hawkActivated && snakeActivated)
        {
            randomPowerBewteenTwo(Random.Range(1,2), boarActivated, hawkActivated);
        }
        //If we don't have any of those three powers
        else
        {
            switch (Random.Range(1, 3))
            {
                case 1:
                    boarActivated = true;
                    break;
                case 2:
                    hawkActivated = true;
                    break;
                case 3:
                    snakeActivated = true;
                    break;
                default:
                    Debug.LogError("Out of random range.");
                    break;
            }
        }
    }

    private void randomPowerBewteenTwo(int random, bool power1, bool power2)
    {
        if (random == 1)
        {
            power1 = true;
        }
        else
        {
            power2 = true;
        }
    }

    public void ToggleMovement()
    {
        movement.ChangeMovementState();
    }

    // getter-setter for Name
    public string Name
    { get; set; }
}
