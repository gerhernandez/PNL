using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    //Wants to know when another object does something interesting 
    public abstract class Observer
    {
        public abstract void OnNotify();
        public abstract void OnNotify(GameObject Sender);
        public abstract bool CheckForRemoval();// check if there is a reason why this observer should be removed.
        public abstract GameObject returnObject();
    }

    public class SambleObserver : Observer
    {
        public GameObject obj;


        Event theEvent;

        Behaviors behaviors;


        public SambleObserver(GameObject obj, Event theEvent)
        {
            this.obj = obj;
            this.theEvent = theEvent;

            behaviors = obj.GetComponent<Behaviors>();
        }

        public override void OnNotify()
        {
            if (theEvent.GetAction() == 1)
            {
                Debug.Log("test event triggered!");
            }
        }

        public override void OnNotify(GameObject sender)
        {
            
            if (theEvent.GetAction() == 1)
            {
                if (sender == obj)
                {
                    //behaviors.();
                }
            }
        }

        public override bool CheckForRemoval()
        {
            if (obj == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override GameObject returnObject()
        {
            return obj;
        }
    }
}