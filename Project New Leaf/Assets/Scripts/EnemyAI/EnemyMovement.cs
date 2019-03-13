using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public LayerMask enemyMask; //this is used to check isGrounded
	public Transform myTrans;
	private float myWidth;
    private float myHeight;

	public float movementspeed;
	private Rigidbody2D rb;
	private float horizontal;
    //Look into Collider, Bounds, and extents

    //This bool is used to determine direction the sprite is facing.
    //This is to be assigned in the inspector during scene editing.
    //True represents facing right, false represents facing left.
    [SerializeField] private bool facing;

    void Start(){
		if(movementspeed == 0f){
			movementspeed = 5f;
		}
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
    }

	void FixedUpdate () {
		moveInBounds();
	}

	void moveInBounds(){
        Vector2 lineCastPos = myTrans.position - myTrans.right*1.1f * myWidth;

        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down * 3);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down * 3, enemyMask);

        Vector2 rightTrans = new Vector2(myTrans.right.x, myTrans.right.y);
        Debug.DrawLine(lineCastPos, lineCastPos - rightTrans * 0.2f);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - rightTrans * 0.2f, enemyMask);

        //If there's no ground, or if I'm blocked I should turn around.
        if (!isGrounded || isBlocked)
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;
        }

        Vector2 myVel = rb.velocity;
        myVel.x = -myTrans.right.x * movementspeed;
        rb.velocity = myVel;
    }

}
