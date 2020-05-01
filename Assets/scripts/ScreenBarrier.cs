using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBarrier : MonoBehaviour {
    public Vector2 direction;
    void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag ("alien")) {
            AlienManager.singleton.ChangeDirection (direction);
        }
    }
}