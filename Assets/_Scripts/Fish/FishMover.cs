using UnityEngine;

public class FishMover : MonoBehaviour
{
    public float horizontalSpeed = 1.0f;
    public float verticalSpeed = 1.0f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public float rotationSpeed = 1.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Move(float horizontalValue, float verticalValue)
    {
        if (horizontalValue != 0) {
            rb.AddForce(Vector2.right * horizontalValue * horizontalSpeed);
        }

        if (verticalValue != 0) {
            rb.AddForce(Vector2.up * verticalValue * verticalSpeed);
        }

        Vector2 v = rb.velocity;
        var angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        var currentZRotation = transform.rotation.eulerAngles.z;
        spriteRenderer.flipY = currentZRotation > 90 && currentZRotation <= 270;
    }
}
