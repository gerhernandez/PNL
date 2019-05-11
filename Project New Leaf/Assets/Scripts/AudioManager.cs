using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

    public AudioSource soundEffects;
    public AudioSource levelMusic;
    public AudioSource[] sources;

    public AudioClip boarCry;
    public AudioClip hawkFly;
    public AudioClip hawkScreech;
    public AudioClip hawkScreech2;
    public AudioClip hit1;
    public AudioClip hit2;
    public AudioClip hit3;
    public AudioClip hitStone;
    public AudioClip stoneCrush;
    public AudioClip viperHiss;
    public AudioClip viperShrink;
    public AudioClip wolfDash;
    public AudioClip wolfDash2;
    public AudioClip wolfHowl;

    public AudioClip storyBlock1;
    public AudioClip storyBlock2;
    public AudioClip storyBlock3;
    public AudioClip storyBlock4;
    public AudioClip level1;
    public AudioClip level2;
    public AudioClip level3;

    public static bool changeVolume;

    public GameObject pauseMenu;

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
        string sceneName = SceneManager.GetActiveScene().name;
        Debug.Log(sceneName);
        switch (sceneName)
        {
            case "StoryBlock1":
                levelMusic.clip = storyBlock1;
                break;
            case "StoryBlock2":
                levelMusic.clip = storyBlock2;
                break;
            case "StoryBlock3":
                levelMusic.clip = storyBlock3;
                break;
            case "StoryBlock4":
                levelMusic.clip = storyBlock4;
                break;
            case "Level1":
                levelMusic.clip = level1;
                break;
            case "Level2":
                levelMusic.clip = level2;
                break;
            case "Level3":
                levelMusic.clip = level3;
                break;

        }
        levelMusic.Play();
    }

    private void Start()
    {
        soundEffects = GetComponent<AudioSource>();
        sources = GetComponentsInChildren<AudioSource>();
        changeVolume = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(PlayAllAudio());
        }
        if (pauseMenu.active == true && changeVolume)
        {
            foreach(AudioSource soundSource in sources)
            {
                soundSource.volume = 0.25f;
                changeVolume = false;
            }
        }
        if(pauseMenu.active == false && changeVolume)
        {
            foreach (AudioSource soundSource in sources)
            {
                soundSource.volume = 1f;
                changeVolume = false;
            }
        }
    }

    IEnumerator PlayAllAudio()
    {
        playBoarCry();
        yield return new WaitForSeconds(1);
        playHawkFly();
        yield return new WaitForSeconds(1);
        playHawkScreech();
        yield return new WaitForSeconds(1);
        playHawkScreech2();
        yield return new WaitForSeconds(1);
        playHit1();
        yield return new WaitForSeconds(1);
        playHit2();
        yield return new WaitForSeconds(1);
        playHit3();
        yield return new WaitForSeconds(1);
        playHitStone();
        yield return new WaitForSeconds(1);
        playStoneCrush();
        yield return new WaitForSeconds(1);
        playViperHiss();
        yield return new WaitForSeconds(1);
        playViperShrink();
        yield return new WaitForSeconds(1);
        playWolfDash();
        yield return new WaitForSeconds(1);
        playWolfDash2();
        yield return new WaitForSeconds(1);
        playWolfHowl();
    }

    public void playBoarCry()
    {
        soundEffects.clip = boarCry;
        soundEffects.Play();
    }

    public void playHawkFly()
    {
        soundEffects.clip = hawkFly;
        soundEffects.Play();
    }

    public void playHawkScreech()
    {
        soundEffects.clip = hawkScreech;
        soundEffects.Play();
    }

    public void playHawkScreech2()
    {
        soundEffects.clip = hawkScreech2;
        soundEffects.Play();
    }

    public void playHit1()
    {
        soundEffects.clip = hit1;
        soundEffects.Play();
    }

    public void playHit2()
    {
        soundEffects.clip = hit2;
        soundEffects.Play();
    }

    public void playHit3()
    {
        soundEffects.clip = hit3;
        soundEffects.Play();
    }

    public void playHitStone()
    {
        soundEffects.clip = hitStone;
        soundEffects.Play();
    }

    public void playStoneCrush()
    {
        soundEffects.clip = stoneCrush;
        soundEffects.Play();
    }

    public void playViperHiss()
    {
        soundEffects.clip = viperHiss;
        soundEffects.Play();
    }

    public void playViperShrink()
    {
        soundEffects.clip = viperShrink;
        soundEffects.Play();
    }

    public void playWolfDash()
    {
        soundEffects.clip = wolfDash;
        soundEffects.Play();
    }

    public void playWolfDash2()
    {
        soundEffects.clip = wolfDash2;
        soundEffects.Play();
    }

    public void playWolfHowl()
    {
        soundEffects.clip = wolfHowl;
        soundEffects.Play();
    }

}
