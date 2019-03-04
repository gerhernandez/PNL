using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public LayerMask enemyMask; //this is used to check isGrounded
	public Transform myTrans;
	private float myWidth;

	public float movementspeed;
	private Rigidbody2D rb;
	private bool facing = true;
	private float horizontal;
	//Look into Collider, Bounds, and extents

	void Start(){
		if(movementspeed == 0f){
			movementspeed = 5f;
		}
		myTrans = this.transform;
		rb = GetComponent<Rigidbody2D>();
		myWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void FixedUpdate () {
		moveInBounds();
	}

	void moveInBounds(){
		Vector2 lineCastPos = myTrans.position - myTrans.right * myWidth;
		
		Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down*4);
		bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down*4, enemyMask);
		
		if(!isGrounded){	
			flip();
		}

		Vector2 myVel = rb.velocity;
		myVel.x = myTrans.right.x * -movementspeed * Time.deltaTime;
		rb.velocity = myVel;
	}

	//Flip the direction that the sprite is facing
	private void flip(){
		facing = !facing;
		Vector3 currRot = myTrans.eulerAngles;
		if(facing){
			currRot.y += 180;
		} else {
			currRot.y -= 180;
		}
		
		myTrans.eulerAngles = currRot;
	}
}
