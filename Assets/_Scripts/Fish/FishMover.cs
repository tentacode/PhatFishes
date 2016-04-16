using UnityEngine;

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
    }

    public void Move(float horizontalValue, float verticalValue)
    {
        if (horizontalValue != 0) {
            rb.AddForce(Vector2.right * horizontalValue * horizontalSpeed);

            spriteRenderer.flipX = horizontalValue > 0;
        }

        if (verticalValue != 0) {
            rb.AddForce(Vector2.up * verticalValue * verticalSpeed);
        }
    }
}
