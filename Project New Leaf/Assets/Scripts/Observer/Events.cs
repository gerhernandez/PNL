using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    //Events
    public abstract class Event
    {
        public abstract int GetAction();



    }

    public class TestEvent : Event
    {
        public override int GetAction()
        {
            return 1;
        }
    }
}
