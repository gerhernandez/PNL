using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour {

    public Button playButton;
    public Button controlsButton;
    public Button creditsButton;
    public Button exitGameButton;
    public Button backControlsButton;
    public Button backCreditsButton;
    public GameObject creditsPanel;
    public GameObject controlsPanel;

    private void Awake()
    {
        playButton.onClick.AddListener(delegate { play("TemporaryScene"); });
        controlsButton.onClick.AddListener(delegate { controls(); });
        creditsButton.onClick.AddListener(delegate { credits(); });
        exitGameButton.onClick.AddListener(delegate { exit(); });
        backControlsButton.onClick.AddListener(delegate { back(); });
        backCreditsButton.onClick.AddListener(delegate { back(); });
    }

    public void play(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void controls()
    {
        controlsPanel.SetActive(true);
    }
    public void credits()
    {
        creditsPanel.SetActive(true);
    }
    public void exit()
    {
        Application.Quit();
    }

    public void back()
    {
        controlsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }
}
