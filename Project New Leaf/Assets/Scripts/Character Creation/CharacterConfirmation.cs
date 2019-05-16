using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//using UnityEngine.SceneManagement;

public class CharacterConfirmation : MonoBehaviour {

	public GameObject popUpCanvas;

    public GameObject finishingTouchesCanvas;

    public GameObject fullBodyCanvas;
    public GameObject fullbodyImage;
    public GameObject restOfFullBody;

    public GameObject characterConfirmation;

    public GameObject playerImage;

    public GameObject paramourImage;

    public EventSystem eventSystem;

    public Button ButtonEditName;

    public Button ButtonNo;

    public Text TextErrorMessage;

    public CharacterCreation CC;

    public LoadScene load;

    public Button finishedButton;

    public bool nowCreateLover = false;

    // Use this for initialization
    void Start () {
        popUpCanvas.SetActive(false);
        characterConfirmation.SetActive(false);
        CC = GetComponent<CharacterCreation>();

        ButtonNo.onClick.AddListener(delegate { Cancel(); } );
        finishedButton.onClick.AddListener(delegate { popUpConfirmation(); });
	}

    void Cancel()
    {
        popUpCanvas.SetActive(false);
        characterConfirmation.SetActive(false);

        fullBodyCanvas.SetActive(false);
        fullbodyImage.SetActive(true);
        restOfFullBody.SetActive(true);

        if (!nowCreateLover)
        {
            playerImage.SetActive(false);
        }
        else
        {
            paramourImage.SetActive(false);
        }

        finishingTouchesCanvas.SetActive(true);
        eventSystem.SetSelectedGameObject(ButtonEditName.gameObject);
    }
	
	public void popUpConfirmation(){
        finishingTouchesCanvas.SetActive(false);
        characterConfirmation.SetActive(true);

        fullBodyCanvas.SetActive(true);
        fullbodyImage.SetActive(true);
        restOfFullBody.SetActive(false);

        if (!nowCreateLover)
        {
            playerImage.SetActive(true);
            paramourImage.SetActive(false);
        }
        else
        {
            playerImage.SetActive(false);
            paramourImage.SetActive(true);
        }

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
                playerImage.SetActive(false);
                fullBodyCanvas.SetActive(false);
                fullbodyImage.SetActive(true);
                restOfFullBody.SetActive(true);
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
            characterConfirmation.SetActive(false);
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
