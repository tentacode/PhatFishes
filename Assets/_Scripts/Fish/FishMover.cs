using UnityEngine;
using System.Collections;

public class FishMover : MonoBehaviour
{
    public float horizontalSpeed = 1.0f;
    public float verticalSpeed = 1.0f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool isShrink = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("P1Action")) {
            if (isShrink) {
                animator.SetTrigger("Blow");
            }
            else {
                animator.SetTrigger("Shrink");
            }

            isShrink = !isShrink;
        }
    }

    void FixedUpdate()
    {
        float horizontalValue = Input.GetAxis("P1Horizontal");
        if (horizontalValue != 0) {
            rb.AddForce(Vector2.right * horizontalValue * horizontalSpeed);

            spriteRenderer.flipX = horizontalValue > 0;
        }

        float verticalValue = Input.GetAxis("P1Vertical");
        if (verticalValue != 0) {
            rb.AddForce(Vector2.up * verticalValue * verticalSpeed);
        }
	}
}
