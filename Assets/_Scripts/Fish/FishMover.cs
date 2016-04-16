using UnityEngine;
using System.Collections;

public class FishMover : MonoBehaviour
{
    public float horizontalSpeed = 1.0f;
    public float verticalSpeed = 1.0f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float horizontalValue = Input.GetAxis("P1Horizontal");
        if (horizontalValue != 0) {
            rb.AddForce(Vector2.right * horizontalValue * horizontalSpeed);
        }

        float verticalValue = Input.GetAxis("P1Vertical");
        if (verticalValue != 0) {
            rb.AddForce(Vector2.up * verticalValue * verticalSpeed);
        }
	}
}
