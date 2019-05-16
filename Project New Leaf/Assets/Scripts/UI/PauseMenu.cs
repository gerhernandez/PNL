using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour {

    public GameObject continueButton;   // To hold the continue button
    public GameObject menuButton;       // To hold the menu button
    public GameObject exitButton;       // To hold the exit button
    public EventSystem eventSystem;     // To hold the Event System object

    private Move moveScript;

    private void OnEnable()
    {
        // Set the current choice to the continue button
        eventSystem.SetSelectedGameObject(continueButton);
    }

    // Use this for initialization
    void Awake () {
        moveScript = FindObjectOfType<Player>().GetComponent<Move>();

        // **** Set all the listeners for each button ****
        continueButton.GetComponent<Button>().onClick.AddListener(delegate { continueGame(); });
        menuButton.GetComponent<Button>().onClick.AddListener(delegate { menu("TitleMenu"); });
        exitButton.GetComponent<Button>().onClick.AddListener(delegate { exit(); });

        // Set the current choice to the continue button
        eventSystem.SetSelectedGameObject(continueButton);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            continueGame();
        }
    }

    /// <summary>
    /// Continue game
    /// </summary>
    public void continueGame()
    {
        Time.timeScale = 1f;            // Resume game, set time back to real time
        AudioManager.changeVolume = true;
        gameObject.SetActive(false);    // set cavas to false
        moveScript.SetMovementState(true);
    }
    
    /// <summary>
    /// Goes back to main menu
    /// </summary>
    /// <param name="scene"> The scene variable will hold the name of the scene to be called </param>
    public void menu(string scene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
    }

    /// <summary>
    /// Exits game, closes unity
    /// </summary>
    public void exit()
    {
        Application.Quit();
    }
}
