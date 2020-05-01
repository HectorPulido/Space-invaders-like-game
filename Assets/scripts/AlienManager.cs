using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ListOfAliens {
    public Alien[] aliens;
}

public class AlienManager : MonoBehaviour {
    public static AlienManager singleton;
    public GameObject explosionPrefab;
    public ListOfAliens[] aliens;
    public float moveFrequency;
    public float step = 0.5f;
    public float stepDown = 0.1f;
    public float stepFrequency = 0.005f;

    private Vector2 currentDirection = Vector2.right;

    // Start is called before the first frame update
    void Start () {
        if (singleton != null) {
            Destroy (this);
        }
        singleton = this;

        StartCoroutine ("MoveAliens");
    }

    // Update is called once per frame
    IEnumerator MoveAliens () {
        while (true) {
            var direction = currentDirection;
            yield return MoveAliensToDirection (direction, step);
        }
    }

    IEnumerator MoveAliensToDirection (Vector2 direction, float step) {
        yield return new WaitForSeconds (moveFrequency);
        for (var i = aliens.Length - 1; i >= 0; i--) {
            foreach (var alien in aliens[i].aliens) {
                if(alien != null){
                    alien.Move (direction * step);
                }
            }
            yield return new WaitForSeconds (moveFrequency / 10);

        }
    }

    public void ChangeDirection (Vector2 direction) {
        currentDirection = direction;
        StartCoroutine (MoveAliensToDirection (Vector2.down, stepDown));
    }
}