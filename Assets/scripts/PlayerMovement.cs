using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    private Rigidbody2D rb;

    public Transform shooter;
    public GameObject bulletPrefab;

    private void Start () {
        rb = GetComponent<Rigidbody2D> ();
    }

    private float inputHorizontal;
    private void Update () {
        inputHorizontal = InputManager.Horizontal;

        if (InputManager.ShootDown) {
            var bullet = Instantiate(bulletPrefab, shooter.position, Quaternion.identity);
            Destroy(bullet.gameObject, 3);
        }
    }

    private void FixedUpdate () {
        var direction = new Vector3 (speed * inputHorizontal, 0);

        rb.MovePosition (transform.position +
            direction * Time.fixedDeltaTime);
    }
}