using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GetPlayerValues getVal;
    public GameObject player;

    public Player PlayerScript;

    // story choice from player created
    public int storyChoice;

    void Awake(){
        PlayerScript = player.GetComponent<Player>();
        storyChoice = getVal.getStoryChoice();
        switch(storyChoice){
            case 1:
                PlayerScript.Health = 5;
                PlayerScript.Mana = 6;
                break;
            case 2:
                PlayerScript.Health = 5;
                PlayerScript.Mana = 4;
                break;
            case 3:
                PlayerScript.Health = 5;
                PlayerScript.Mana = 4;
                break;
            case 4:
                PlayerScript.Health = 4;
                PlayerScript.Mana = 3;
                break;
            case 5:
                PlayerScript.Health = 4;
                PlayerScript.Mana = 2;
                break;
            case 6:
                PlayerScript.Health = 3;
                PlayerScript.Mana = 2;
                break;
            default:
                PlayerScript.Health = 1;
                PlayerScript.Mana = 1;
                break;
        }
    }
    void Start()
    {
        Debug.Log("Story Choice: " + storyChoice);
        Debug.Log("Health: " + PlayerScript.Health);
        Debug.Log("Mana: " + PlayerScript.Mana);
    }

    void Update()
    {
       // storyChoice = getVal.getStoryChoice();
    }
}
