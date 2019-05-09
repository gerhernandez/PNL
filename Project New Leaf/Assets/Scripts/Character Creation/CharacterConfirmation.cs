using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//using UnityEngine.SceneManagement;

public class CharacterConfirmation : MonoBehaviour {

	public GameObject popUpCanvas;

    public GameObject finishingTouchesCanvas;

    public EventSystem eventSystem;

    public Button ButtonEditName;
    public Button ButtonNo;

    public Text TextErrorMessage;

    public CharacterCreation CC;

    public LoadScene load;

    bool nowCreateLover;

	// Use this for initialization
	void Start () {
        popUpCanvas.SetActive(false);
        nowCreateLover = false;
        CC = GetComponent<CharacterCreation>();

        ButtonNo.onClick.AddListener(delegate { Cancel(); } );
	}

    void Cancel()
    {
        popUpCanvas.SetActive(false);
        finishingTouchesCanvas.SetActive(true);
        eventSystem.SetSelectedGameObject(ButtonEditName.gameObject);
    }
	
	public void popUpConfirmation(){
        finishingTouchesCanvas.SetActive(false);
		popUpCanvas.SetActive(true);
        eventSystem.SetSelectedGameObject(popUpCanvas.GetComponentInChildren<Button>().gameObject);
    }

	public void Confirmation(Button btn){
		if (btn.name.Equals("YesBtn") && (CC.getPronounInt() > 0 && CC.getCisTranInt() > 0)) {
            if (!nowCreateLover && !CC.playerName.Equals(""))
            {
                CC.createPlayer();
                CC.resetForLover();
                popUpCanvas.SetActive(false);
                nowCreateLover = true;
            }
            else if (nowCreateLover && !CC.paramourName.Equals(""))
            {
                CC.createLover();
                popUpCanvas.SetActive(false);
                
                load.SetAndLoadScene("StoryBlock1");
            }
            CC.nameInput.text = "";
            CC.keyboardTextField.text = "";
		}
        else if (btn.name.Equals("YesBtn") && (CC.getPronounInt() == 0 || CC.getCisTranInt() == 0 || CC.playerName.Equals("")))
        {
            if (!nowCreateLover)
            {
                popUpCanvas.SetActive(false);
            }
            else if (nowCreateLover)
            {
                popUpCanvas.SetActive(false);
            }
            finishingTouchesCanvas.SetActive(true);
            eventSystem.SetSelectedGameObject(ButtonEditName.gameObject);

            StartCoroutine(ErrorMessage());
        }
	}

    IEnumerator ErrorMessage()
    {
        TextErrorMessage.enabled = true;
        yield return new WaitForSeconds(1.5f);
        TextErrorMessage.enabled = false;
    }
}
