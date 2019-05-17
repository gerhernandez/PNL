using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Methods : MonoBehaviour {

    public GameObject tarotReader;
    public GameObject mentor;
    public GameObject evilEntity;
    public GameObject paramour;

    public Animator mentorController;

	// Use this for initialization
	void Start () {
        paramour = GameObject.Find("Paramour");
        paramour.SetActive(false);

        tarotReader = GameObject.Find("TarotCardReader");

        mentor = GameObject.Find("Mysterious Figure");
        mentor.SetActive(true);

        evilEntity = GameObject.Find("EvilEntity");
        mentorController = evilEntity.GetComponent<Animator>();
        evilEntity.SetActive(false);
	}
    
    public void ActivateSwitch()
    {
        mentor.SetActive(false);
        evilEntity.SetActive(true);
        StartCoroutine("MentorTransformation");
    }

    public void ActivateParamour()
    {
        StartCoroutine("TriggerTheEnd");
    }

    IEnumerator MentorTransformation()
    {
        mentorController.SetBool("Transforming", true);
        yield return new WaitForSeconds(2f);
        mentorController.SetBool("Idle", true);
    }

    IEnumerator TriggerTheEnd()
    {
        /*
        float beginRotation = 0f;
        
        while (beginRotation < 360f)
        {
            evilEntity.transform.Rotate(new Vector3(0f, 0f, beginRotation));
            tarotReader.transform.Rotate(new Vector3(0f, 0f, beginRotation));

            beginRotation += 45f;
        }*/

        Destroy(evilEntity);
        Destroy(tarotReader);
        paramour.SetActive(true);

        yield return new WaitForSeconds(1f);
    }
}
