using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : MonoBehaviour {

    // booleans for power activation
    /*public static bool hasFlyingPower = false;
    public static bool hasBoarPower = false;
    public static bool hasSnakePower = false;
    public static bool hasWolfPower = false;
    */
    /** TODO:*/ 
    public static bool hasFlyingPower = true;
    public static bool hasBoarPower = true;
    public static bool hasSnakePower = true;
    public static bool hasWolfPower = true;
    /**/

    private Move MoveScript;
    public HealthManager healthManager;
    private const int depleteManaByOne = -1;

    float maxV = 0;

    #region Player Variables

    // variables of Player
    public BoxCollider2D playerCollider;
    private Rigidbody2D playerRigidbody;

    #endregion

    #region Wolf Variables
    public float DashForce;

    [SerializeField]
    private bool isWolfDashing;
    
    #endregion

    #region Snake Variables

    // dimensions and center of playerCollider
    private Vector2 playerOriginalScale;
    private Vector2 playerOriginalCenter;

    private bool isCrawling;

    #endregion

    #region Boar Variables

    // boar variables
    [SerializeField]
    private bool isCharging;
    private const float chargeRecoil = 2f;

    #endregion

    #region Flying Variables

    [SerializeField]
    private bool isFlying;
    private bool canStillFly;
    public float flyingVelocity;

    [SerializeField]
    private float flyingTime;
    public float flyingDepletionPoint;

    #endregion
    
    private void Start()
    {
        // Health Manager
        healthManager = GameObject.Find("Manager").GetComponentInChildren<HealthManager>();

        // player start values
        MoveScript = GetComponent<Move>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();

        // snake start values
        playerOriginalScale = playerCollider.size;
        playerOriginalCenter = playerCollider.offset;
        
        flyingTime = 0f;
        canStillFly = true;

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
    }
    
    #region Wolf Power

    public void WolfPower()
    {
        if (!MoveScript.GetIsPlayerInteracting())
        {
            bool dashingDown = (Input.GetButtonDown("ButtonX") && Input.GetAxis("VerticalX") > 0.25f);

            if (!dashingDown && Input.GetButtonDown("ButtonX") && !isWolfDashing)
            {
                healthManager.updateManaDisplay(depleteManaByOne);
                isWolfDashing = true;
                StartCoroutine(StartDash());
            }
            else if (dashingDown && !isWolfDashing && !Move.grounded)
            {
                StartDive();
                healthManager.updateManaDisplay(depleteManaByOne);
                isWolfDashing = true;
            }

            // why was this put here in the first place? did it do something?
            //if(!dashingDown && isWolfDashing && Move.grounded)
            //{
            //    isWolfDashing = false;
            //}
        }
        
    }

    public IEnumerator StartDash()
    {
        playerRigidbody.gravityScale = 0f;
        if (!MoveScript.IsPlayerFacingRight())
        {
            playerRigidbody.AddForce(-Vector2.right * DashForce);
        }
        else if (MoveScript.IsPlayerFacingRight())
        {
            playerRigidbody.AddForce(Vector2.right * DashForce);
        }
        yield return new WaitForSeconds(2f);
        playerRigidbody.gravityScale = 1f;
        isWolfDashing = false;

    }

    public void StartDive()
    {
        if (!Move.grounded)
        {
            playerRigidbody.AddForce(-Vector2.up * DashForce * 2f);
        }
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
            if (Input.GetButton("ButtonY") && !isCrawling && Move.grounded && healthManager.attemptManaConsumption())
            {
                isCrawling = true;
                playerCollider.size = new Vector2(1f, .5f);
                playerCollider.offset = new Vector2(0f, -3f);
                healthManager.updateManaDisplay(depleteManaByOne);
                HealthManager.rechargeEnabled = false;
            }
            else if (Input.GetButtonUp("ButtonY") && isCrawling)
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
        if (collision.gameObject.tag == "Breakable")
        {
            if (!healthManager.attemptManaConsumption() && !Move.grounded)
            {
                return;
            }

            // when player presses the B button on the xbox controller, and a power has not been activated yet
            if (Input.GetButton("ButtonB") && !isCharging && hasBoarPower && !MoveScript.GetIsPlayerInteracting())
            {
                healthManager.updateManaDisplay(depleteManaByOne);
                isCharging = true;
                MoveScript.ChangeMovementState();

                if (MoveScript.IsPlayerFacingRight())
                {
                    playerRigidbody.AddForce(-transform.right * chargeRecoil, ForceMode2D.Impulse);
                }
                else if (!MoveScript.IsPlayerFacingRight())
                {
                    playerRigidbody.AddForce(transform.right * chargeRecoil, ForceMode2D.Impulse);
                }

                Destroy(collision.gameObject);
                StartCoroutine(BoarPowerActivated());
            }
        }
    }

    // Start of the coroutine, delay of one second is placed per boar smash
    // This could also hold the animation and switching of sprites
    IEnumerator BoarPowerActivated()
    {
        yield return new WaitForSeconds(1);
        isCharging = false;
        MoveScript.ChangeMovementState();
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
            isFlying = false;
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
            }
        }
        else
        {
            flyingTime = 0f;
            playerRigidbody.gravityScale = 1f;
            playerRigidbody.drag = 0f;
        }
    }

    public bool IsPlayerFlying()
    {
        return isFlying;
    }
    #endregion
}
