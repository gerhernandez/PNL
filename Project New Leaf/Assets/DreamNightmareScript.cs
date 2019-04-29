using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamNightmareScript : MonoBehaviour {

    private static DreamNightmareScript instance = null;
    public static DreamNightmareScript Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
