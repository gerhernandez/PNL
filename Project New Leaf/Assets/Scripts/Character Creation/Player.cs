using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IAction<Input>, IDirectionalMove<Input>, IChangeStatus<int>
{
    // variables
    public string playerName;
    public int healthPoints;
    public int magicPoints;

    // essential attributes will go here

    // cosmetics
    private int hair;
    private int eyes;
    private int top;
    private int bottom;
    private int footwear;

    public void Action(Input action)
    {
        // do action based on Input
    }    
    
    public void Move(Input direction)
    {
        // go in direction based on Input
    }

    public void ChangeStatus(int status)
    {
        // change given status
    }

}
