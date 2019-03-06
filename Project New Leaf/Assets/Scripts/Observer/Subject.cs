using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    //Invokes the notificaton method
    public class Subject : MonoBehaviour
    {
        //A list with observers that are waiting for something to happen
        public List<Observer> observers = new List<Observer>();

        //Send notifications if something has happened
        public void Notify()
        {
            for (int i = 0; i < observers.Count; i++)
            {
                //Notify all observers even though some may not be interested in what has happened
                //Each observer should check if it is interested in this event
                observers[i].OnNotify();
            }
        }

        public void Notify(GameObject coinObj)
        {
            for (int i = 0; i < observers.Count; i++)
            {
                observers[i].OnNotify(coinObj);
                //scanForRemoval();
            }
        }

        //Add observer to the list
        public void AddObserver(Observer observer)
        {
            observers.Add(observer);
        }

        //Remove observer from the list
        public void RemoveObserver(Observer observer)
        {
            Debug.Log(observers.Count);
            observers.Remove(observer);
            Debug.Log(observers.Count);
        }

        public void scanForRemoval()  //unused currently
        {
            for (int i = 0; i < observers.Count; i++)
            {
                if (observers[i].CheckForRemoval())
                {
                    RemoveObserver(observers[i]);
                }
            }
        }
    }
}