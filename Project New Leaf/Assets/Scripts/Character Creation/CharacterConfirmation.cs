using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class CharacterConfirmation : MonoBehaviour {

	public Canvas popUpCanvas;

	public CharacterCreation CC;

    public LoadScene load;

    bool nowCreateLover;

	// Use this for initialization
	void Start () {
		popUpCanvas.enabled = false;
        nowCreateLover = false;
        CC = GetComponent<CharacterCreation>();
	}
	
	public void popUpConfirmation(){
		popUpCanvas.enabled = true;
	}

	public void Confirmation(Button btn){
		if (btn.name.Equals("YesBtn") && (CC.getPronounInt() > 0 || CC.getCisTranInt() > 0)) {
            if (!nowCreateLover)
            {
                CC.createPlayer();
                CC.resetForLover();
                popUpCanvas.enabled = false;
                nowCreateLover = true;
            }
            else if (nowCreateLover)
            {
                CC.createLover();
                popUpCanvas.enabled = false;

                // load the new scene and wait for the full scene to load
                //StartCoroutine(LoadAsyncScene());
                load.SetAndLoadScene("Confirmation");
            }
		}
        else if (btn.name.Equals("YesBtn") && (CC.getCisTranInt() == 0 || CC.getCisTranInt() == 0))
        {
            if (!nowCreateLover)
            {
                Debug.Log("NO GO BACK AND PICK YOUR Player's CT AND PR INTS!!");
                Debug.Log("Int: " + CC.getCisTranInt());
                Debug.Log("Int: " + CC.getCisTranInt());
                popUpCanvas.enabled = false;
            }
            else if (nowCreateLover)
            {
                Debug.Log("NO GO BACK AND PICK YOUR Paramour's CT AND PR INTS!!");
                Debug.Log("Int: " + CC.getCisTranInt());
                Debug.Log("Int: " + CC.getCisTranInt());
                popUpCanvas.enabled = false;
            }
        }
        else
        {
			popUpCanvas.enabled = false;
		}
	}
    /*
    IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Confirmation");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    */
}
