using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : MonoBehaviour {

    [SerializeField]
    private Vector2 leftDestination;
    [SerializeField]
    private Vector2 rightDestination;
    [SerializeField]
    private Vector2 nextDestination;
    private Transform platformTrans;
    private const int MAGNITUDE = 1;

    public float offset;

	// Use this for initialization
	void Start () {
        platformTrans = this.transform;
        leftDestination = new Vector2(platformTrans.position.x - offset, platformTrans.position.y);
        rightDestination = new Vector2(platformTrans.position.x + offset, platformTrans.position.y);
        nextDestination = leftDestination;
	}
	
	// Update is called once per frame
	void Update () {
        platformTrans.position = Vector2.MoveTowards(platformTrans.position, nextDestination, .5f);
		if(Vector2.Distance(platformTrans.position, nextDestination) < MAGNITUDE)
        {
            if(nextDestination == leftDestination)
            {
                nextDestination = rightDestination;
            }
            else
            {
                nextDestination = leftDestination;
            }
        }
	}
}
