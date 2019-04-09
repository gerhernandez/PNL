using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{

    public class GameController : MonoBehaviour
    {

        public GameObject[] observedArray; //You can use this to store game objects that currently have an observer watching them.

        Subject subject = new Subject();

        void Start()
        {

                //SambleObserver newObser = new SambleObserver(observedArray[i], new TestEvent());
                //subject.AddObserver(newObser);
        }

        void Update()
        {
            //you can put the code for checking if an event you are looking for has happened in here

            /*
            for (int i = 0; i < observedArray.Length; i++)
            {
                if ()
                {
                    subject.Notify(observedArray[i]);
                }
            }
            */
        }

        public bool removeFromObservedArray(GameObject toRemove)
        {
            int index = System.Array.IndexOf(observedArray, toRemove);

            for (int i = index + 1; i < observedArray.Length; i++)
            {
                observedArray[i - 1] = observedArray[i];
            }
            System.Array.Resize(ref observedArray, observedArray.Length - 1);

            int count = subject.observers.Count;
            for (int i = 0; i < subject.observers.Count; i++)
            {
                count = subject.observers.Count;
                if (toRemove == subject.observers[i].returnObject())
                {
                    subject.RemoveObserver(subject.observers[i]);
                    i--;
                }
            }

            return true;
        }

    }
}