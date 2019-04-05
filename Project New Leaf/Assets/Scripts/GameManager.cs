using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GetPlayerValues getVal;

    // story choice from player created
    public int storyChoice;

    void Start()
    {
        storyChoice = 0;
    }

    void Update()
    {
       // storyChoice = getVal.getStoryChoice();
    }
}
