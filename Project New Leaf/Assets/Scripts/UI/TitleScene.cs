using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TitleScene : MonoBehaviour {
    public GameManager[] managers = null;          // managers inside scene    
    public GameObject fungusManager = null;

    public GameObject DreamNight_music;

    public GameObject playButton;           // To hold the play button
    public GameObject controlsButton;       // To hold the control button
    public GameObject creditsButton;        // To hold the credits button
    public GameObject exitGameButton;       // To hold the exit game button
    public GameObject backControlsButton;   // To hold the back button in controls
    public GameObject backCreditsButton;    // To hold the back button in credits
    public GameObject creditsPanel;         // To hold the credits panel
    public GameObject controlsPanel;        // To hold the controls panel
    public EventSystem eventSystem;         // To hold the Event System object

    private void Awake()
    {
        // **** Set all the listeners for each button ****
        playButton.GetComponent<Button>().onClick.AddListener(delegate { play("Dream-Nightmare"); });
        controlsButton.GetComponent<Button>().onClick.AddListener(delegate { controls(); });
        creditsButton.GetComponent<Button>().onClick.AddListener(delegate { credits(); });
        exitGameButton.GetComponent<Button>().onClick.AddListener(delegate { exit(); });
        backControlsButton.GetComponent<Button>().onClick.AddListener(delegate { back(); });
        backCreditsButton.GetComponent<Button>().onClick.AddListener(delegate { back(); });

        // Set the current choice to the continue button
        eventSystem.SetSelectedGameObject(playButton);
    }

    // when the scene is loaded, delete any existing managers
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // delete any Managers in the scene
        managers = FindObjectsOfType<GameManager>();

        fungusManager = GameObject.Find("FungusManager");

        if (managers != null && managers.Length > 0)
        {
            foreach(GameManager m in managers)
            {
                DestroyObject(m.gameObject);
            }
        }

        // if the fungusManager exists, destroy it
        if (fungusManager != null)
        {
            DestroyObject(fungusManager);
        }

        // instantiate music
        Instantiate(DreamNight_music);
    }

    /// <summary>
    /// Start Game: Loads the first scene (Prologue)
    /// </summary>
    /// <param name="scene"> Prologue scene </param>
    public void play(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    /// <summary>
    /// Controls Panel: Shows an image or directions of the controls of the game.
    /// </summary>
    public void controls()
    {
        controlsPanel.SetActive(true);

        // set other buttons inactive
        playButton.SetActive(false);
        controlsButton.SetActive(false);
        creditsButton.SetActive(false);
        exitGameButton.SetActive(false);

        eventSystem.SetSelectedGameObject(backControlsButton);
    }

    /// <summary>
    /// Credits Panel: Shows the name of people who created the game
    /// </summary>
    public void credits()
    {
        creditsPanel.SetActive(true);

        // set other buttons inactive
        playButton.SetActive(false);
        controlsButton.SetActive(false);
        creditsButton.SetActive(false);
        exitGameButton.SetActive(false);

        eventSystem.SetSelectedGameObject(backCreditsButton);
    }

    /// <summary>
    /// Exit Game
    /// </summary>
    public void exit()
    {
        Application.Quit();
    }

    /// <summary>
    /// Goes back from the panel to the main menu
    /// </summary>
    public void back()
    {
        controlsPanel.SetActive(false);
        creditsPanel.SetActive(false);

        // set other buttons active
        playButton.SetActive(true);
        controlsButton.SetActive(true);
        creditsButton.SetActive(true);
        exitGameButton.SetActive(true);

        eventSystem.SetSelectedGameObject(playButton);
    }
}
