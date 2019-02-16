using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IAction<Input>, IDirectionalMove<Input>, IChangeStatus<int>, IAbilities<int>
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
    
    public void UseAbility(int ability)
    {
        // use ability based on wanted ability
    }
}
