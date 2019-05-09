using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

// player inherits from BasicPlayer
public class Player : MonoBehaviour
{
    [SerializeField] private HealthManager hm;
    [SerializeField] private Move movement;

    public Rigidbody2D rb;
    public SpriteRenderer drawn;

    public bool isDamaged;
    public int Health, Mana;

    private bool boarActivated, hawkActivated, wolfActivated, snakeActivated;

    protected Animator myAnimator;
    
    protected int hairpos;
    protected int storyArc;
    
    private string playerName;    

    private static bool startPositionLVL2 = false;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        
    }

    // start
    void Start()
    {
        hm = GameObject.FindObjectOfType<HealthManager>();

        drawn = GetComponent<SpriteRenderer>();
        myAnimator = this.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        movement = this.GetComponent<Move>();
        hairpos = PlayerSelectedAttributes.PlaySelectedHairPos;
        wolfActivated = true;

        if(SceneManager.GetActiveScene().name == "Level2"){
            Debug.Log(startPositionLVL2);
            if(startPositionLVL2 == true){
                this.transform.position = GameObject.Find("StartPositionA").transform.position;
            }
            else
            {
                this.transform.position = GameObject.Find("StartPositionB").transform.position;
            }
        }

        boarActivated = Powers.hasBoarPower;
        hawkActivated = Powers.hasFlyingPower;
        wolfActivated = Powers.hasWolfPower;
        snakeActivated = Powers.hasSnakePower;
    }
    
    void Update(){
        // nothing so far in Player Update
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.tag == "Damage" && !isDamaged)
        {
            //We tell our health manager that our player has taken damage
            hm.updateHealthDisplay(-1);
            StartCoroutine("TakeDamage");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checking to see where the player ends in level 1 for starting position in level 2
        if(collision.gameObject.name == "LoadNextSceneA" || collision.gameObject.name == "LoadNextSceneB"){
            startPositionLVL2 = true;
        }
        else if(collision.gameObject.name == "LoadNextSceneC" || collision.gameObject.name == "LoadNextSceneD"){
            startPositionLVL2 = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Damage" && !isDamaged)
        {
            hm.updateHealthDisplay(-1);
            StartCoroutine("TakeDamage");
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

    public void UpgradeStats()
    {
        hm.upgradeMaxHealth();
        hm.upgradeMaxMana();

        //If at least one of these powers isn't activated.
        if (!boarActivated || !hawkActivated || !snakeActivated)
        {
            unlockRandomPower();
        }
        else
        {
            //Tell fungus to continue moving
        }
    }

    public void unlockRandomPower()
    {
        //Only if we don't have the snake power
        if (boarActivated && hawkActivated && !snakeActivated)
        {
            snakeActivated = true;
            Powers.hasSnakePower = true;
        }
        //Only if we don't have the hawk power
        else if (boarActivated && !hawkActivated && snakeActivated)
        {
            hawkActivated = true;
            Powers.hasFlyingPower = true;
        }
        //Only if we don't have the boar power
        else if (!boarActivated && hawkActivated && snakeActivated)
        {
            boarActivated = true;
            Powers.hasBoarPower = true;
        }
        //If we only have the boar power
        else if (boarActivated && !hawkActivated && !snakeActivated)
        {
            int random = Random.Range(1, 3);

            if (random == 1)
            {
                hawkActivated = true;
                Powers.hasFlyingPower = true;
            }
            else
            {
                snakeActivated = true;
                Powers.hasSnakePower = true;
            }
        }
        //If we only have the hawk power
        else if (!boarActivated && hawkActivated && !snakeActivated)
        {
            int random = Random.Range(1, 3);

            if (random == 1)
            {
                boarActivated = true;
                Powers.hasBoarPower = true;
            }
            else
            {
                snakeActivated = true;
                Powers.hasSnakePower = true;
            }
        }
        //If we only have the snake power
        else if (!boarActivated && !hawkActivated && snakeActivated)
        {
            int random = Random.Range(1, 3);

            if (random == 1)
            {
                boarActivated = true;
                Powers.hasBoarPower = true;
            }
            else
            {
                hawkActivated = true;
                Powers.hasFlyingPower = true;
            }
        }
        //If we don't have any of those three powers
        else
        {
            switch (Random.Range(1, 4))
            {
                case 1:
                    boarActivated = true;
                    Powers.hasBoarPower = true;
                    break;
                case 2:
                    hawkActivated = true;
                    Powers.hasFlyingPower = true;
                    break;
                case 3:
                    snakeActivated = true;
                    Powers.hasSnakePower = true;
                    break;
                default:
                    Debug.LogError("Out of random range.");
                    break;
            }
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