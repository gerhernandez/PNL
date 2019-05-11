using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource source;
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

    public static bool changeVolume;

    public GameObject pauseMenu;

    private void Start()
    {
        source = GetComponent<AudioSource>();
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
        source.clip = boarCry;
        source.Play();
    }

    public void playHawkFly()
    {
        source.clip = hawkFly;
        source.Play();
    }

    public void playHawkScreech()
    {
        source.clip = hawkScreech;
        source.Play();
    }

    public void playHawkScreech2()
    {
        source.clip = hawkScreech2;
        source.Play();
    }

    public void playHit1()
    {
        source.clip = hit1;
        source.Play();
    }

    public void playHit2()
    {
        source.clip = hit2;
        source.Play();
    }

    public void playHit3()
    {
        source.clip = hit3;
        source.Play();
    }

    public void playHitStone()
    {
        source.clip = hitStone;
        source.Play();
    }

    public void playStoneCrush()
    {
        source.clip = stoneCrush;
        source.Play();
    }

    public void playViperHiss()
    {
        source.clip = viperHiss;
        source.Play();
    }

    public void playViperShrink()
    {
        source.clip = viperShrink;
        source.Play();
    }

    public void playWolfDash()
    {
        source.clip = wolfDash;
        source.Play();
    }

    public void playWolfDash2()
    {
        source.clip = wolfDash2;
        source.Play();
    }

    public void playWolfHowl()
    {
        source.clip = wolfHowl;
        source.Play();
    }

}
