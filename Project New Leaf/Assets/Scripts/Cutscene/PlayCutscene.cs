using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayCutscene : MonoBehaviour {
    public LoadScene load;

    public Text title;

    public VideoClip cutscene;
    public VideoPlayer player;

    public bool play;

	// Use this for initialization
	void Start () {
        player = GetComponent<VideoPlayer>();
        player.clip = cutscene;
        player.targetCamera = GetComponent<Camera>();
        StartCoroutine(startPlay());
	}

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            load.SetAndLoadScene("Jessica_CharacterCreation");
        }
    }

    IEnumerator startPlay()
    {
        Debug.Log("Entered startPlay()");
        Debug.Log("cutscene length: " + cutscene.length);
        player.Play();
        yield return new WaitForSeconds((float) cutscene.length);
        load.SetAndLoadScene("Jessica_CharacterCreation");
    }
}
