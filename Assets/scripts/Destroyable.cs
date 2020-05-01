using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag ("bullet")) {
            Destroy (gameObject);
            Destroy(other.gameObject);
        }
    }
}
