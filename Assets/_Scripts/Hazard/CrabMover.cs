using UnityEngine;
using System.Collections;

public class CrabMover : MonoBehaviour
{
    public int changeDirectionIntervalMin = 1;
    public int changeDirectionIntervalMax = 3;

    public float moveSpeed = 1;
    private int direction;
    private Rigidbody2D rb;

	void Start()
	{
        direction = Random.value < 0.5f ? -1 : 1;

        ChangeDirection();
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hazard") {
            CancelInvoke();
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        direction = -direction;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(moveSpeed * direction, 0);

        Invoke("ChangeDirection", changeDirectionIntervalMin + (Random.value * changeDirectionIntervalMax));
    }

	void Update()
	{

	}
}
