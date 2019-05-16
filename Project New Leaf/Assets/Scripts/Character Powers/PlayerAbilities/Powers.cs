using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Powers : MonoBehaviour {

    // booleans for power activation
    public static bool hasFlyingPower = false;
    public static bool hasBoarPower = false;
    public static bool hasSnakePower = false;
    public static bool hasWolfPower = true;

    private AudioManager audioManager;
    private AudioSource audioSource;
    private AudioMixer mixer;
    public AudioClip boarCry;
    public AudioClip hawkFly;
    public AudioClip viperHiss;
    public AudioClip wolfDash;

    private Move MoveScript;
    public HealthManager healthManager;
    private const int depleteManaByOne = -1;
    
    #region Player Variables

    // variables of Player
    public BoxCollider2D playerCollider;
    private Rigidbody2D playerRigidbody;

    #endregion
    
    #region Wolf Variables
    public float DashForce;
    public float wolfDashDuration;
    public float betweenDashesTimer;
    private float dashTimer;

    private bool isWolfDashing;
    private bool wolfDashingRight;
    private bool dashTimerSet;
    #endregion
    
    #region Boar Variables

    // boar variables
    [SerializeField]
    private bool isCharging;
    private const float chargeRecoil = 0.5f;
    private bool isBoarOnTheSide = false;
    private RaycastHit2D sideHit;

    public LayerMask boarLayerMask;

    #endregion

    #region Flying Variables
    private bool isFlying;
    private bool canStillFly;
    public float flyingVelocity;

    private float flyingTime;
    public float flyingDepletionPoint;
    private bool playedFlySound;
    #endregion

    #region Snake Variables

    // dimensions and center of playerCollider
    private Vector2 playerOriginalScale;
    private Vector2 playerOriginalCenter;

    [SerializeField]
    private bool isCrawling;
    public LayerMask groundLayer;

    #endregion

    private void Start()
    {
        // Health Manager
        healthManager = GameObject.Find("Manager").GetComponentInChildren<HealthManager>();
        audioManager = FindObjectOfType<AudioManager>();
        audioSource = GetComponent<AudioSource>();
        mixer = Resources.Load("AudioMixer") as AudioMixer;

        // player start values
        MoveScript = GetComponent<Move>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();

        // snake start values
        playerOriginalScale = playerCollider.size;
        playerOriginalCenter = playerCollider.offset;

        dashTimer = 0;
        dashTimerSet = false;

        flyingTime = 0f;
        canStillFly = true;
        playedFlySound = false;

        isCrawling = false;
        isFlying = false;
        isCharging = false;
        isWolfDashing = false;
    }

    private void Update()
    {
        if (hasFlyingPower)
        {
            FlyingMovement();
        }
        if (hasSnakePower)
        {
            SnakePower();
        }
        if (hasWolfPower)
        {
            WolfPower();
        }
        if (hasBoarPower)
        {
            CheckIfBoarIsOnTheSideOfBreakableBox();
        }

        if (dashTimerSet)
        {
            dashTimer += Time.deltaTime;
            if(dashTimer >= betweenDashesTimer)
            {
                dashTimerSet = false;
                dashTimer = 0;
            }
        }
    }
    
    #region Wolf Power

    public void WolfPower()
    {
        if (!MoveScript.GetIsPlayerInteracting())
        {
            if (Input.GetButtonDown("ButtonX") && !dashTimerSet && !isWolfDashing && healthManager.attemptManaConsumption())
            {
                healthManager.updateManaDisplay(depleteManaByOne);
                isWolfDashing = true;
                StartCoroutine(StartDash());
            }

            if (!MoveScript.IsPlayerFacingRight() && wolfDashingRight && isWolfDashing)
            {
                playerRigidbody.velocity = new Vector2(-0.5f, playerRigidbody.velocity.y);
                playerRigidbody.gravityScale = 1f;
                isWolfDashing = false;
            }
            else if (MoveScript.IsPlayerFacingRight() && !wolfDashingRight && isWolfDashing)
            {
                playerRigidbody.velocity = new Vector2(0.5f, playerRigidbody.velocity.y);
                playerRigidbody.gravityScale = 1f;
                isWolfDashing = false;
            }
        }
    }

    public IEnumerator StartDash()
    {
        audioSource.clip = wolfDash;
        audioSource.outputAudioMixerGroup = mixer.FindMatchingGroups("Wolf")[0];
        audioSource.Play();
        playerRigidbody.gravityScale = 0.0f;
        playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0f);
        if (!MoveScript.IsPlayerFacingRight())
        {
            playerRigidbody.AddForce(-Vector2.right * DashForce);
            wolfDashingRight = false;
        }
        else if (MoveScript.IsPlayerFacingRight())
        {
            playerRigidbody.AddForce(Vector2.right * DashForce);
            wolfDashingRight = true;
        }
        yield return new WaitForSeconds(wolfDashDuration);
        dashTimerSet = true;
        playerRigidbody.velocity = new Vector2(0.5f, playerRigidbody.velocity.y);
        playerRigidbody.gravityScale = 1f;
        isWolfDashing = false;

    }

    public bool IsWolfDashing()
    {
        return isWolfDashing;
    }

    #endregion

    #region Snake Power
    /// <summary>
    /// Snake Power shrinks player to fit under small crawl spaces
    /// </summary>
    public void SnakePower()
    {
        if (!Move.grounded)
        {
            return;
        }

        if(!MoveScript.GetIsPlayerInteracting())
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 1.0f, groundLayer);

            if (Input.GetButton("ButtonY") && !isCrawling && healthManager.attemptManaConsumption())
            {
                audioSource.clip = viperHiss;
                audioSource.outputAudioMixerGroup = mixer.FindMatchingGroups("Viper")[0];
                audioSource.Play();
                isCrawling = true;
                playerCollider.size = new Vector2(1f, .5f);
                playerCollider.offset = new Vector2(0f, -3f);
                healthManager.updateManaDisplay(depleteManaByOne);
                HealthManager.rechargeEnabled = false;
            }
            else if (!Input.GetButton("ButtonY") && isCrawling && hit.collider == null)
            {
                isCrawling = false;
                playerCollider.size = playerOriginalScale;
                playerCollider.offset = playerOriginalCenter;
                healthManager.updateManaDisplay(depleteManaByOne);
                HealthManager.rechargeEnabled = true;
            }
        }
        
    }

    public bool IsViperCrawling()
    {
        return isCrawling;
    }

    #endregion

    #region Boar Power

    /// <summary>
    /// OnCollisionStay2D method: Used when player is attempting to use boar power on a crate
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay2D(Collision2D collision)
    {
        // check if collision is of tag breakable
        if (collision.gameObject.tag == "Breakable" /*&& isBoarOnTheSide*/)
        {

            // when player presses the B button on the xbox controller, and a power has not been activated yet
            if (Input.GetButtonDown("ButtonB") && healthManager.attemptManaConsumption() && !isCharging && hasBoarPower)
            {
                healthManager.updateManaDisplay(depleteManaByOne);
                isCharging = true;
                StartCoroutine(BoarPowerActivated(collision));
            }
        }
    }

    private void CheckIfBoarIsOnTheSideOfBreakableBox()
    {
        if (MoveScript.IsPlayerFacingRight())
        {
            sideHit = Physics2D.Raycast(transform.position, Vector2.right, 1.0f, boarLayerMask);
            Debug.DrawRay(transform.position, Vector2.right, Color.red);
        }
        else if (!MoveScript.IsPlayerFacingRight())
        {
            sideHit = Physics2D.Raycast(transform.position, Vector2.left, 1.0f, boarLayerMask);
            Debug.DrawRay(transform.position, Vector2.left, Color.red);
        }

        if (sideHit.collider == null)
        {
            isBoarOnTheSide = false;
            return;
        }
        else if (sideHit.collider.gameObject.tag != "Breakable")
        {
            isBoarOnTheSide = false;
        }
        else if (sideHit.collider.gameObject.tag == "Breakable")
        {
            isBoarOnTheSide = true;
        }
    }

    // Start of the coroutine, delay of one second is placed per boar smash
    // This could also hold the animation and switching of sprites
    IEnumerator BoarPowerActivated(Collision2D collision)
    {
        //Boar starts charging
        HealthManager.rechargeEnabled = false;
        MoveScript.SetMovementState(false);
        audioSource.clip = boarCry;
        audioSource.outputAudioMixerGroup = mixer.FindMatchingGroups("Boar")[0];
        audioSource.Play();
        yield return new WaitForSeconds(1f);

        //The boar hits the boulder
        Destroy(collision.gameObject);
        if (MoveScript.IsPlayerFacingRight())
        {
            playerRigidbody.AddForce(-transform.right * chargeRecoil, ForceMode2D.Impulse);
        }
        else if (!MoveScript.IsPlayerFacingRight())
        {
            playerRigidbody.AddForce(transform.right * chargeRecoil, ForceMode2D.Impulse);
        }
        audioManager.playStoneCrush();
        yield return new WaitForSeconds(1f);

        //Boar is no longer being used
        isCharging = false;
        HealthManager.rechargeEnabled = true;
        MoveScript.SetMovementState(true);
    }

    public bool IsCharging()
    {
        return isCharging;
    }
    #endregion

    #region Flying Power

    //---------------------------------------------
    // Flying starts
    //---------------------------------------------

    void FlyingMovement()
    {
        if (Move.grounded)
        {
            if (isFlying)
            {
                isFlying = false;
                audioSource.Stop();
            }
            
            if (!IsViperCrawling())
            {
                HealthManager.rechargeEnabled = true;
            }
            return;
        }
        
        else if(!Move.grounded && healthManager.attemptManaConsumption())
        {
            canStillFly = true;
        }

        if (MoveScript.GetJumpCount() == 3 && !MoveScript.GetIsPlayerInteracting() && !isFlying && canStillFly)
        {
            isFlying = true;
            healthManager.updateManaDisplay(depleteManaByOne);
            HealthManager.rechargeEnabled = false;
        }

        if (isFlying)
        {
            if (Input.GetButton("ButtonA") && canStillFly)
            {
                if (!playedFlySound)
                {
                    playedFlySound = true;
                    StartCoroutine(playFlySound());
                }
                flyingTime += Time.deltaTime;
                
                if (flyingTime >= flyingDepletionPoint)
                {
                    flyingTime = 0f;
                    if (healthManager.attemptManaConsumption())
                    {
                        healthManager.updateManaDisplay(depleteManaByOne);
                    } else
                    {
                        canStillFly = false;
                        return;
                    }
                }
                playerRigidbody.gravityScale = 0.3f;
                playerRigidbody.drag = 0.7f;
                playerRigidbody.AddForce(transform.up * flyingVelocity, ForceMode2D.Impulse);
            }
            else if (Input.GetButtonUp("ButtonA"))
            {
                isFlying = false;
                canStillFly = false;
                audioSource.Stop();
            }
        }
        else
        {
            flyingTime = 0f;
            if (!isWolfDashing)
            {
                playerRigidbody.gravityScale = 1f;
            }
            playerRigidbody.drag = 0f;
        }
    }

    public bool IsPlayerFlying()
    {
        return isFlying;
    }

    private IEnumerator playFlySound()
    {
        audioSource.clip = hawkFly;
        audioSource.outputAudioMixerGroup = mixer.FindMatchingGroups("Hawk")[0];
        audioSource.Play();
        yield return new WaitForSeconds(4.5f);
        playedFlySound = false;
    }
    #endregion
}
