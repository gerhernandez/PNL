using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    private HealthManager hm;

    // Use this for initialization
    void Start()
    {
        hm = FindObjectOfType<HealthManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hm.setCheckPoint(new Vector2(this.transform.position.x, this.transform.position.y));
            hm.resetCurrHealth();
            hm.resetCurrMana();
        }
    }
}
