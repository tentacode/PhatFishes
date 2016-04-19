using UnityEngine;

public class MineMover : MonoBehaviour
{
    public float fallSpeed = 10;
    public float rotationSpeed = 10;
    private Rigidbody2D rb;

	void Start()
	{
        rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
        rb.velocity = new Vector2(0, -1 * fallSpeed);
        transform.Rotate(0, 0, rotationSpeed);
	}
}
