using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAction<T>
{
    void Action(T action);
}

public interface IDirectionalMove<T>
{
    void Move(T direction);
}

public interface IChangeStatus<T>
{
    void ChangeStatus(T status);
}
