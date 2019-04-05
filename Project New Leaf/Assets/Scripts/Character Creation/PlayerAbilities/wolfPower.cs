using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfPower : MonoBehaviour {

    Player player;

    Rigidbody2D playerRb;

    //values used for balancing our dash ability
    public float DashDistance = 3f;
    public float DashForce = 40f;
    public float DashCooldown = 1f;

    //values used for balancing the dive ability
    public float DiveSpeed = 2f;

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

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<Player>();
        playerRb = player.GetComponent<Rigidbody2D>();
        collidedIntoWallOrSlope = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetAxis("Vertical") < 0)
        {
            StartDive();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartDash();
        }
	}

    public virtual void StartDash()
    { 
        // If the user presses the dash button and is not aiming down
            // if the character is allowed to dash
        if (_cooldownTimeStamp <= Time.time)
        {
            _cooldownTimeStamp = Time.time + DashCooldown;
            StartCoroutine(Dash());
        }
    }

    public virtual void StartDive()
    {
        if (_cooldownTimeStamp <= Time.time)
        {
            _cooldownTimeStamp = Time.time + DashCooldown;
            StartCoroutine(Dive());
        }
    }

    protected virtual IEnumerator Dive()
    {

    // while the player is not grounded, we force it to go down fast
        while (!player.grounded)
        {
            playerRb.velocity = new Vector2(0, -DiveSpeed*10);
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
        
        //TODO: Check which way player is facing for direction of force
        _dashDirection = 1f;//_character.IsFacingRight ? 1f : -1f;
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
                playerRb.velocity = Vector2.zero;
            }
            else
            {
                playerRb.gravityScale = 0;
                playerRb.velocity = new Vector2(playerRb.velocity.x, 0);
                playerRb.AddForce(new Vector2(_computedDashForce, 0));
            }
            yield return null;
        }

        // once our dash is complete, we reset our various states
        //_controller.Parameters.MaximumSlopeAngle = _slopeAngleSave;
        Debug.Log("Ending dash");
        playerRb.velocity = new Vector2(0, 0);
        playerRb.gravityScale = 1f;
        _dashEndedNaturally = true;
        collidedIntoWallOrSlope = false;

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Terrain")
        {
            collidedIntoWallOrSlope = true;
        }
    }
}
