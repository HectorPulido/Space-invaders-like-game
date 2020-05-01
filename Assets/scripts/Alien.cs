using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour {
    public void Move (Vector3 dir) {
        transform.position += dir;
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag ("bullet")) {
            Destroy (gameObject);
            Destroy(other.gameObject);
            var explosion = Instantiate (
                AlienManager.singleton.explosionPrefab, 
                transform.position, 
                Quaternion.identity
                );
            Destroy(explosion, 1);

            AlienManager.singleton.moveFrequency -= AlienManager.singleton.stepFrequency;
        }
    }
}