using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TitleScene : MonoBehaviour {

    public GameObject playButton;
    public GameObject controlsButton;
    public GameObject creditsButton;
    public GameObject exitGameButton;
    public GameObject backControlsButton;
    public GameObject backCreditsButton;
    public GameObject creditsPanel;
    public GameObject controlsPanel;
    public EventSystem eventSystem;

    private void Awake()
    {
        playButton.GetComponent<Button>().onClick.AddListener(delegate { play("CharacterCreation"); });
        controlsButton.GetComponent<Button>().onClick.AddListener(delegate { controls(); });
        creditsButton.GetComponent<Button>().onClick.AddListener(delegate { credits(); });
        exitGameButton.GetComponent<Button>().onClick.AddListener(delegate { exit(); });
        backControlsButton.GetComponent<Button>().onClick.AddListener(delegate { back(); });
        backCreditsButton.GetComponent<Button>().onClick.AddListener(delegate { back(); });
        eventSystem.SetSelectedGameObject(playButton);
    }

    public void play(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void controls()
    {
        controlsPanel.SetActive(true);
        eventSystem.SetSelectedGameObject(backControlsButton);
    }
    public void credits()
    {
        creditsPanel.SetActive(true);
        eventSystem.SetSelectedGameObject(backCreditsButton);
    }
    public void exit()
    {
        Application.Quit();
    }

    public void back()
    {
        controlsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        eventSystem.SetSelectedGameObject(playButton);
    }
}
