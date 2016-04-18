using UnityEngine;
using System.Collections;

public class FishHealth : MonoBehaviour
{
    public float invulnerabilityFrame = 1.0f;
    public Color invulnerableColor = Color.red;

    private int health = 1;
    private float lastHitTime = 0;
    private SpriteRenderer spriteRenderer;
    private GameManager gameManager;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("Game").GetComponent<GameManager>();
    }

    void Update()
    {
        if (IsInvulnerable()) {
            spriteRenderer.material.SetColor("_ColorTint", invulnerableColor);
        } else {
            spriteRenderer.material.SetColor("_ColorTint", Color.white);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Hazard") {
            this.Hurt();
        }
    }

    bool IsInvulnerable()
    {
        if (lastHitTime == 0) {
            return false;
        }

        return Time.time < lastHitTime + invulnerabilityFrame;
    }

    void Hurt()
    {
        if (IsInvulnerable() || health == 0 || gameManager.IsGameEnded()) {
            return;
        }

        health -= 1;
        if (health == 0) {
            Die();

            return;
        }

        lastHitTime = Time.time;
    }

    void Die()
    {
        GetComponent<FishInput>().enabled = false;

        Animator animator = GetComponent<Animator>();
        animator.ResetTrigger("Shrink");
        animator.ResetTrigger("Blow");

        if (GetComponent<FishPhysics>().IsShrinked()) {
            animator.SetTrigger("DeathShrink");
        } else {
            animator.SetTrigger("DeathBig");
        }

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = -2;
    }

    public int GetHealth()
    {
        return health;
    }
}
