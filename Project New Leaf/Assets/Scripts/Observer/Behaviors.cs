using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviors : MonoBehaviour
{

    public GameObject gameControllerObject;
    public ObserverPattern.GameController gameController;

    // Use this for initialization
    void Start()
    {
        gameControllerObject = GameObject.Find("GameController");
        gameController = gameControllerObject.GetComponent<ObserverPattern.GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

}
