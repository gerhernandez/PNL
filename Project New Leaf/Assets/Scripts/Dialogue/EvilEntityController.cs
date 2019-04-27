using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilEntityController : MonoBehaviour {

    public Animator control;
    public SpriteRenderer drawn;

    // Use this for initialization
    void Start()
    {
        control = GetComponent<Animator>();
        drawn = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            playTransformation();
        }
    }

    public void playTransformation()
    {
        control.SetBool("Transforming", true);
        control.SetBool("Idle", false);
        StartCoroutine(Wait());
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        StopTransformation();
    }

    void StopTransformation()
    {
        control.SetBool("Transforming", false);
        control.SetBool("Idle", true);
    }

}
