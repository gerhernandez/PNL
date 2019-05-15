using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private FiniteStateMachine<EnemyMovement> FSM;
    public enum EnemyStates { Idle, Chasing, Afraid };
    public EnemyStates currentState;

    //public bool switchStateButton;


    //public LayerMask enemyMask; //this is used to check isGrounded
    public Transform myTrans;
    private float myWidth;
    private float myHeight;

    public float idleMovementSpeed;
    public float chasingMovementSpeed;
    public float afraidMovementSpeed;
    private Rigidbody2D rb;
    private float horizontal;

    public bool jumpOnTurn;

    public bool bounceWhenChasing;
    public bool moveWhenIdle;

//    public FlowchartLoader flowchartLoader;
    public bool racist;
    public bool sexist;
    public bool transphobic;
    public bool crazy;

    public bool aggressionTriggered;
    public float aggressionRadius;
    public bool cowardly;

    public bool rangedAttack;
    public int rangedAttackReloadTime;
    public int rangedAttackCurrentReload;
    public GameObject rangedAttackPrefab;
    public float maximumThrowX;
    public float maximumThrowY;
    public float minimumThrowX;
    public float minimumThrowY;

    public bool jumped;  //these should both be false if the object falls from something without making a jump
    public bool onGround;

    public GameObject playerTarget;
    

    public Vector2 jumpForce;

    //Look into Collider, Bounds, and extents

    //This bool is used to determine direction the sprite is facing.
    //This is to be assigned in the inspector during scene editing.
    //True represents facing right, false represents facing left.
    [SerializeField]
    private bool facing;

    void Start()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player");
        
        myTrans = this.transform;
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer mySprite = this.GetComponent<SpriteRenderer>();

        myWidth = mySprite.bounds.extents.x;
        myHeight = mySprite.bounds.extents.y;

        if (!facing)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        if (crazy)
        {
            aggressionTriggered = true;
        }
        else if (racist && PlayerSelectedAttributes.StoryChoice >= 4)
        {
            aggressionTriggered = true;
        }
        else if (sexist && PlayerSelectedAttributes.StoryChoice % 3 != 1)
        {
            aggressionTriggered = true;
        }
        else if (transphobic && PlayerSelectedAttributes.StoryChoice % 3 == 0)
        {
            aggressionTriggered = true;
        }
    }

    

    void Awake()
    {
        FSM = new FiniteStateMachine<EnemyMovement>();
        FSM.Configure(this, EnemyIdle.Instance);
    }

    public void ChangeState(FSMState<EnemyMovement> e)
    {
        FSM.ChangeState(e);
    }

    void FixedUpdate()
    {
        checkForFloor();
        FSM.Update();
        if (lowBlockDetector())
        {
            attemptJump();
        }
    }

    void checkForFloor()
    {
        Vector2 groundDetector = myTrans.position - myTrans.up * 1.01f * myHeight;
        Vector2 downTrans = new Vector2(myTrans.up.x, -1 * myTrans.up.y);
        Debug.DrawLine(groundDetector, groundDetector + downTrans * .2f, Color.blue);
        bool grounded = Physics2D.Linecast(groundDetector, groundDetector + downTrans * .01f);
        Debug.Log("Enemy grounded: " + grounded);
        if (grounded)
        {
            jumped = false;
            onGround = true;
        }
        else
        {
            onGround = false;
        }
    }
    
    bool edgeDetector()
    {
        Vector2 lineCastPos = myTrans.position - myTrans.right * 1.1f * myWidth;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down * 3, Color.red);
        return Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down * 3);
    }

    bool blockDetector()
    {
        Vector2 lineCastPos = myTrans.position - myTrans.right * 1.01f * myWidth;
        Vector2 rightTrans = new Vector2(myTrans.right.x, myTrans.right.y);
        Debug.DrawLine(lineCastPos, lineCastPos - rightTrans * 0.1f, Color.yellow);
        return Physics2D.Linecast(lineCastPos, lineCastPos - rightTrans * 0.1f);
    }

    bool lowBlockDetector()
    {
        Vector2 lineCastPos = myTrans.position - myTrans.right * 1.01f * myWidth - myTrans.up * 1.7f * myWidth;
        Vector2 rightTrans = new Vector2(myTrans.right.x, myTrans.right.y);
        Debug.DrawLine(lineCastPos, lineCastPos - rightTrans * 0.05f, Color.cyan);
        return Physics2D.Linecast(lineCastPos, lineCastPos - rightTrans * 0.05f);
    }

    void moveInBounds()
    {
        if ((!edgeDetector() && onGround) || blockDetector())
        {
            flip();
        }


        Vector2 myVel = rb.velocity;
        myVel.x = -myTrans.right.x * idleMovementSpeed;
        rb.velocity = myVel;
    }

    void moveToTarget()
    {
        Vector2 directionToTarget = playerTarget.transform.position - transform.position;
        if (directionToTarget.x > 3)
        {
            if (!facing)
            {
                flip();
            }
        }
        if (directionToTarget.x < -3)
        {
            if (facing)
            {
                flip();
            }
        }
        if (bounceWhenChasing)
        {
            attemptJump();
        }

        Vector2 myVel = rb.velocity;
        myVel.x = -myTrans.right.x * chasingMovementSpeed;
        rb.velocity = myVel;
    }

    void moveAwayFromTarget()
    {
        
        Vector2 directionToTarget = playerTarget.transform.position - transform.position;
        if (directionToTarget.x < 0)
        {
            if (!facing)
            {
                flip();
            }
        }
        if (directionToTarget.x > 0)
        {
            if (facing)
            {
                flip();
            }
        }
        if (bounceWhenChasing)
        {
            attemptJump();
        }

        Vector2 myVel = rb.velocity;
        myVel.x = -myTrans.right.x * afraidMovementSpeed;
        rb.velocity = myVel;
    }


    private void attemptRangedAttack()
    {
        if (rangedAttackReloadTime <= 0)
        {
            Debug.Log("rangedAttackReloadTime must be a positive number");
        }
        else {
            if (rangedAttackCurrentReload == 0)
            {
                GameObject thrownRock = Instantiate(rangedAttackPrefab, gameObject.transform.position + gameObject.transform.right * (gameObject.transform.lossyScale.x * 3f), Quaternion.identity);
                Rigidbody2D thrownRockBody = thrownRock.GetComponent<Rigidbody2D>();
                Vector2 throwforce = new Vector2(gameObject.transform.right.x * -1 * UnityEngine.Random.Range(minimumThrowX, maximumThrowX), UnityEngine.Random.Range(minimumThrowY, maximumThrowY));
                thrownRockBody.AddForce(throwforce);
                rangedAttackCurrentReload = rangedAttackReloadTime;
            }
            else rangedAttackCurrentReload--;
        }
    }

    private bool attemptJump()
    {
        if (onGround)
        {
            rb.AddForce(jumpForce);
            jumped = true;
            onGround = false;
            return true;
        }
        else return false;
    }
    private void randomPush()
    {
        float xForce = UnityEngine.Random.Range(-jumpForce.y, jumpForce.y);
        Vector2 force = new Vector2(xForce, 0f);
    }
    private void flip()
    {
        if (jumpOnTurn)
        {
            attemptJump();
        }
        Vector3 currRot = myTrans.eulerAngles;
        currRot.y += 180;
        myTrans.eulerAngles = currRot;
        facing = !facing;
    }

    public sealed class EnemyIdle : FSMState<EnemyMovement>
    {
        static readonly EnemyIdle instance = new EnemyIdle();
        public static EnemyIdle Instance
        {
            get
            {
                return instance;
            }
        }
        static EnemyIdle() { }
        private EnemyIdle() { }

        public override void Enter(EnemyMovement entity)
        {
            entity.currentState = EnemyStates.Idle;
            Debug.Log("Entered Idle State");
            //throw new NotImplementedException();
        }

        public override void Execute(EnemyMovement entity)
        {
            if (entity.moveWhenIdle)
            { entity.moveInBounds(); }

            if (entity.lowBlockDetector())
            {
                entity.attemptJump();
            }

            if (((entity.playerTarget.transform.position - entity.gameObject.transform.position).magnitude < entity.aggressionRadius) && entity.aggressionTriggered)
            {
                if (!entity.cowardly)
                {
                    entity.ChangeState(EnemyChasing.Instance);
                }
                else
                {
                    entity.ChangeState(EnemyAfraid.Instance);
                }
            }
        }

        public override void Exit(EnemyMovement entity)
        {
            Debug.Log("Exited Idle State");
            //throw new NotImplementedException();
        }
    }
    public sealed class EnemyChasing : FSMState<EnemyMovement>
    {
        static readonly EnemyChasing instance = new EnemyChasing();
        public static EnemyChasing Instance
        {
            get
            {
                return instance;
            }
        }
        static EnemyChasing() { }
        private EnemyChasing() { }

        public override void Enter(EnemyMovement entity)
        {
            entity.currentState = EnemyStates.Chasing;
            Debug.Log("Entered Chasing State");
            //throw new NotImplementedException();
        }

        public override void Execute(EnemyMovement entity)
        {
            entity.moveToTarget();
            if (entity.lowBlockDetector())
            {
                entity.attemptJump();
            }
            if ((entity.playerTarget.transform.position - entity.gameObject.transform.position).magnitude > entity.aggressionRadius && entity.aggressionTriggered)
            {
                entity.ChangeState(EnemyIdle.Instance);
            }
            if (entity.rangedAttack)
            { entity.attemptRangedAttack(); }
        }

        public override void Exit(EnemyMovement entity)
        {
            Debug.Log("Exited Chasing State");
            //throw new NotImplementedException();
        }
    }
    public sealed class EnemyAfraid : FSMState<EnemyMovement>
    {
        static readonly EnemyAfraid instance = new EnemyAfraid();
        public static EnemyAfraid Instance
        {
            get
            {
                return instance;
            }
        }
        static EnemyAfraid() { }
        private EnemyAfraid() { }
        public override void Enter(EnemyMovement entity)
        {
            entity.currentState = EnemyStates.Afraid;
            //throw new NotImplementedException();
        }

        public override void Execute(EnemyMovement entity)
        {
            entity.moveAwayFromTarget();
            if (entity.lowBlockDetector())
            {
                entity.attemptJump();
            }
            if ((entity.playerTarget.transform.position - entity.gameObject.transform.position).magnitude > entity.aggressionRadius && entity.aggressionTriggered)
            {
                entity.ChangeState(EnemyIdle.Instance);
            }


            //throw new NotImplementedException();
        }

        public override void Exit(EnemyMovement entity)
        {
            //throw new NotImplementedException();
        }
    }

    private void jumpOutOfLava()
    {
        if(attemptJump())
        {
            randomPush();
        }
    }

    public void OnCollisionEnter2D(Collision collision)
    {
        if (collision.gameObject == playerTarget)
        {
            Debug.Log("Hit the player");
        }
    }
}