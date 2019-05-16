using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCanvasScript : MonoBehaviour {

    // Use this for initialization

    public int lifespan;
    public float speed;
    private RectTransform rectTransform;
    private int remaining;
	void Start () {
        remaining = lifespan;
        rectTransform = gameObject.GetComponent<RectTransform>();
	}

    private void FixedUpdate()
    {
        if (remaining > 0)
        {
            remaining--;
            rectTransform.position += new Vector3(0, speed);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
