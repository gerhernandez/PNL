using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarotCardScript : MonoBehaviour {

    public GameObject paramour;
    public GameObject tarrotCardReader;

	public void DestroyObjects()
    {
        Destroy(paramour);
        Destroy(tarrotCardReader);
    }
}
