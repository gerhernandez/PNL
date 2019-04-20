using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_AnimationControl : MonoBehaviour {
    public Animator control;
    public SpriteRenderer drawn;
    public TestMove move;

	// Use this for initialization
	void Start () {
        control = GetComponent<Animator>();
        drawn = GetComponent<SpriteRenderer>();
        move = GetComponentInParent<TestMove>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            control.SetBool("isWalking", true);
        }
        else if (Input.GetAxis("Horizontal") == 0)
        {
            control.SetBool("isWalking", false);
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            drawn.flipX = true;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            drawn.flipX = false;
        }

        if (TestMove.grounded == false)
        {
            control.SetBool("jumpStart", true);
        }
        else if (TestMove.grounded == true)
        {
            control.SetBool("jumpStart", false);
            control.SetBool("jumpEnd", true);
            StartCoroutine("TestWait");
        }
    }

    IEnumerator TestWait()
    {
        yield return new WaitForSeconds(0.3f);
        control.SetBool("jumpEnd", false);
    }
}
