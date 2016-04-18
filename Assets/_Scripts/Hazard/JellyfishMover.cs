using UnityEngine;
using System.Collections.Generic;

public class JellyfishMover : MonoBehaviour
{
    public float jumpHeight = 10.0f;
    public float jumpWidth = 10.0f;
    public float jumpFrequency = 3.0f;
    public float jumpDuration = 1.0f;
    public float fallSpeed = 3.0f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRender;
    private bool isJumping = false;


	void Start()
	{
        rb = GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();

        Invoke("JumpToNearestTarget", 1);
	}

    void JumpToNearestTarget()
    {
        isJumping = true;
        Invoke("StopJumping", jumpDuration);

        var players = GameObject.FindGameObjectsWithTag("Player");
        List<GameObject> alivePlayers = new List<GameObject>();

        foreach (GameObject player in players) {
            if (player.GetComponent<FishHealth>().GetHealth() > 0) {
                alivePlayers.Add(player);
            }
        }

        GameObject target = alivePlayers.Count > 0 ?
            alivePlayers[Random.Range(0, alivePlayers.Count)] :
            players[Random.Range(0, players.Length)]
        ;

        JumpToTarget(target);

        Invoke("JumpToNearestTarget", jumpFrequency);
    }

    void StopJumping()
    {
        isJumping = false;
    }

    void JumpToTarget(GameObject target)
    {
        Vector2 direction = (target.transform.position - transform.position).normalized;
        direction.x = direction.x * jumpWidth;
        direction.y = transform.position.y > target.transform.position.y ? -0.5f * jumpHeight : jumpHeight;

        rb.velocity = direction;
    }

    void Update()
    {
        if (!isJumping) {
            rb.velocity = new Vector2(rb.velocity.x, -1 * fallSpeed);
        }

        spriteRender.flipX = rb.velocity.x > 0;
    }
}
