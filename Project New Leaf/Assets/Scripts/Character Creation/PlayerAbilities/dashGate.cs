using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashGate : MonoBehaviour {

    private void OnTriggerEnter2D(Collider other)
    {
        if(other.tag == "playerDash")
        {
            Physics2D.IgnoreCollision(other.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
