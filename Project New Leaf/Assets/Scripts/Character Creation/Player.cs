using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IAction<string>, IChangeStatus<int>, IAbilities<int>
{
    // variables
    public string playerName;
    public int healthPoints;
    public int magicPoints;

    // essential attributes will go here

    // cosmetics
    public int hair;
    public int eyes;
    public int top;
    public int bottom;
    public int footwear;

    // instance of Player

    /** TODO */
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Debug.Log("getting pressed\n");
        Move("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space pressed\n");
            Action("jump");
        }
    }

    public void Action(string act)
    {
        // do action based on Input
        // for jumping
        if (act.Equals("jump"))
        {
            Debug.Log("Jump entered\n");
            rb.AddForce(transform.position * 2);
        }
    }    
    
    public void Move(string dir)
    {
        // go in direction based on Input
        Debug.Log("Input: " + Input.GetAxis(dir) + "\n");
        Debug.Log("Direction: " + dir + "\n");
        rb.AddForce(transform.right * Input.GetAxis(dir) * 2);
    }

    public void ChangeStatus(int status)
    {
        // change given status
    }
    
    public void UseAbility(int ability)
    {
        // use ability based on wanted ability
    }
}
