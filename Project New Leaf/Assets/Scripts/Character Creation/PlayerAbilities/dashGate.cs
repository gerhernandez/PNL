using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashGate : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.tag == "PlayerDash")
        {
            Physics2D.IgnoreCollision(other.GetComponentInParent<BoxCollider2D>(), GetComponent<BoxCollider2D>(), true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PlayerDash")
        {
            Physics2D.IgnoreCollision(other.GetComponentInParent<BoxCollider2D>(), GetComponent<BoxCollider2D>(), false);
        }
    }
}
