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

    #region Player Variables

    // variables of Player
    public BoxCollider2D playerCollider;
    private Rigidbody2D playerRigidbody;

    #endregion

    #region Snake Variables

    // dimensions and center of playerCollider
    public Vector2 playerOriginalScale;
    public Vector2 playerOriginalCenter;

    [SerializeField]
    private bool isCrawling;

    #endregion

    #region Boar Variables

    // boar variables
    [SerializeField]
    private bool isCharging;
    private const float chargeRecoil = 2f;

    #endregion

    #region Wolf Variables

    AnimationControl control;
    CircleCollider2D dashGateZone;

    [SerializeField]
    private bool isWolfDashing;

    //values used for balancing our dash ability
    private float DashDistance = 10f;
    private float DashForce = 25f;
    private float DashCooldown = 1f;

    //values used for balancing the dive ability
    private float DiveSpeed = 10f;

    private bool collidedIntoWallOrSlope;

    //initial timeStamp for our dash, updated when we use dash function
    protected float _cooldownTimeStamp = 0;

    //Variables used for our dash function
    protected float _startTime;
    protected Vector3 _initialPosition;
    protected float _dashDirection;
    protected float _distanceTraveled = 0f;
    protected bool _shouldKeepDashing = true;
    protected float _computedDashForce;
    protected float _slopeAngleSave = 0f;
    protected bool _dashEndedNaturally = true;

    #endregion

    #region Flying Variables

    [SerializeField]
    private bool isFlying;
    public float flyingVelocity;

    [SerializeField]
    private float flyingTime;
    public float flyingDepletionPoint;

    #endregion
    
    private void Start()
    {
        // player start values
        MoveScript = GetComponent<Move>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        //healthManager = GetComponent<HealthManager>();

        // snake start values
        playerOriginalScale = playerCollider.size;
        playerOriginalCenter = playerCollider.offset;

        // wolf start values
        control = this.gameObject.GetComponentInChildren<AnimationControl>();
        collidedIntoWallOrSlope = false;
        dashGateZone = GetComponentInChildren<CircleCollider2D>();
        dashGateZone.enabled = false;

        flyingTime = 0f;

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
        if (!healthManager.attemptManaConsumption())
        {
            return;
        }

        if (!MoveScript.GetIsPlayerInteracting())
        {
            if (Input.GetButtonDown("ButtonX") && !isWolfDashing)
            {
                //Debug.Log("Trying to Dash");
                StartDash();
                healthManager.updateManaDisplay(depleteManaByOne);
                isWolfDashing = true;
            }
            else if ((Input.GetButtonDown("ButtonX") && Input.GetAxis("VerticalX") > 0.8f) && !isWolfDashing)
            {
                //Debug.Log("Trying to Dive");
                StartDive();
                healthManager.updateManaDisplay(depleteManaByOne);
                isWolfDashing = true;
            }

            if(Input.GetButtonUp("ButtonX") && isWolfDashing)
            {
                isWolfDashing = false;
            }
        }
        
    }

    public virtual void StartDash()
    {
        // If the user presses the dash button and is not aiming down
        // if the character is allowed to dash
        //if (_cooldownTimeStamp <= Time.time)
        //{
        //    _cooldownTimeStamp = Time.time + DashCooldown;
        //    StartCoroutine(Dash());
        //}
        if (!MoveScript.IsPlayerFacingRight())
        {
            Debug.Log("Trying to Dash right");
        }
        else if (MoveScript.IsPlayerFacingRight())
        {
            Debug.Log("Trying to Dash left");
            //playerRigidbody.AddForce(transform.right * chargeRecoil * 1000, ForceMode2D.Force);
        }
    }

    public virtual void StartDive()
    {
        //if (_cooldownTimeStamp <= Time.time)
        //{
        //    _cooldownTimeStamp = Time.time + DashCooldown;
        //    StartCoroutine(Dive());
        //}

        if (!Move.grounded)
        {
            playerRigidbody.AddForce(-transform.up * chargeRecoil, ForceMode2D.Impulse);
        }
        
    }

    protected virtual IEnumerator Dive()
    {

        // while the player is not grounded, we force it to go down fast
        while (!Move.grounded)
        {
            playerRigidbody.velocity = new Vector2(0, -DiveSpeed * 10);
            yield return 0; //go to next frame
        }

    }

    protected virtual IEnumerator Dash()
    {

        // we initialize our various counters and checks
        _startTime = Time.time;
        _dashEndedNaturally = false;
        _initialPosition = this.transform.position;
        _distanceTraveled = 0;
        _shouldKeepDashing = true;
        dashGateZone.enabled = true;

        //TODO: Check which way player is facing for direction of force
        if (!control.drawn.flipX)
        {
            _dashDirection = 1f;
        }
        else
        {
            _dashDirection = -1f;
        }
        _computedDashForce = DashForce * _dashDirection;

        // we keep dashing until we've reached our target distance or until we get interrupted
        while (_distanceTraveled < DashDistance && _shouldKeepDashing /*&& _movement.CurrentState == CharacterStates.MovementStates.Dashing*/)
        {
            _distanceTraveled = Vector3.Distance(_initialPosition, this.transform.position);

            // if we collide with something on our left or right (wall, slope), we stop dashing, otherwise we apply horizontal force
            if (/*(_controller.State.IsCollidingLeft || _controller.State.IsCollidingRight)*/ collidedIntoWallOrSlope)
            {
                collidedIntoWallOrSlope = false;
                _shouldKeepDashing = false;
                playerRigidbody.velocity = Vector2.zero;
            }
            else
            {
                playerRigidbody.gravityScale = 0.001f;
                playerRigidbody.velocity = new Vector2(_computedDashForce, 0);
            }
            yield return null;
        }

        // once our dash is complete, we reset our various states
        //_controller.Parameters.MaximumSlopeAngle = _slopeAngleSave;
        Debug.Log("Ending dash");
        playerRigidbody.gravityScale = 1f;
        _dashEndedNaturally = true;
        collidedIntoWallOrSlope = false;
        dashGateZone.enabled = false;
        playerRigidbody.velocity = new Vector2(_computedDashForce * 10f, 0);

    }

    #endregion

    #region Snake Power
    /// <summary>
    /// Snake Power shrinks player to fit under small crawl spaces
    /// </summary>
    public void SnakePower()
    {
        if (!healthManager.attemptManaConsumption())
        {
            return;
        }

        if(!MoveScript.GetIsPlayerInteracting())
        {
            if (Input.GetButton("ButtonY") && !isCrawling)
            {
                isCrawling = true;
                playerCollider.size = new Vector2(1f, .5f);
                playerCollider.offset = new Vector2(0f, -3f);
                healthManager.updateManaDisplay(depleteManaByOne);

            }
            if (Input.GetButtonUp("ButtonY") && isCrawling)
            {
                isCrawling = false;
                playerCollider.size = playerOriginalScale;
                playerCollider.offset = playerOriginalCenter;
                healthManager.updateManaDisplay(depleteManaByOne);
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
            if (!healthManager.attemptManaConsumption())
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
        if (!healthManager.attemptManaConsumption())
        {
            return;
        }

        if (MoveScript.GetJumpCount() == 3 && !MoveScript.GetIsPlayerInteracting() && !isFlying)
        {
            isFlying = true;
            healthManager.updateManaDisplay(depleteManaByOne);
        }

        if (isFlying)
        {
            if (Input.GetButton("ButtonA"))
            {
                flyingTime += Time.deltaTime;

                if (flyingTime >= flyingDepletionPoint)
                {
                    flyingTime = 0f;
                    healthManager.updateManaDisplay(depleteManaByOne);
                }

                playerRigidbody.gravityScale = 0.3f;
                playerRigidbody.drag = 0.7f;
                playerRigidbody.AddForce(transform.up * flyingVelocity, ForceMode2D.Impulse);
            }
            else if (Input.GetButtonUp("ButtonA"))
            {
                isFlying = false;
                MoveScript.SetJumpCount(1);
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
