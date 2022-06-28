using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package") {
            Debug.Log("Package picked up");
            Destroy(other.gameObject, 0);
        } else {
            Debug.Log("triggered");
        }
    }
}
