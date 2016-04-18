using UnityEngine;

public class FishPhysics : MonoBehaviour
{
    public bool isShrink = false;
    public float cooldown = 1.0f;

    public AudioClip blowAudioClip;
    private AudioSource audioSource;

    [Header("Shrink physics")]
    public float shrinkMass;
    public float shrinkDrag;
    private BoxCollider2D boxCollider;

    [Header("Blow physics")]
    public float blowMass;
    public float blowDrag;
    private CircleCollider2D circleCollider;

    private Animator animator;
    private Rigidbody2D rb;

    private float lastActionTime = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        circleCollider = GetComponent<CircleCollider2D>();
        boxCollider = GetComponent<BoxCollider2D>();

        Init();
    }

    void Init()
    {
        if (isShrink) {
            Shrink();
        } else {
            Blow();
        }
    }

    void Shrink()
    {
        rb.mass = shrinkMass;
        rb.drag = shrinkDrag;
        boxCollider.enabled = true;
        circleCollider.enabled = false;
        isShrink = true;
        animator.ResetTrigger("Blow");
        animator.SetTrigger("Shrink");
    }

    void Blow()
    {
        Debug.Log("Play");
        audioSource.Stop();
        audioSource.clip = blowAudioClip;
        audioSource.Play();

        rb.mass = blowMass;
        rb.drag = blowDrag;
        circleCollider.enabled = true;
        boxCollider.enabled = false;
        isShrink = false;
        animator.ResetTrigger("Shrink");
        animator.SetTrigger("Blow");
    }

    public void ToggleBlow()
    {
        if (lastActionTime != 0 && Time.time < lastActionTime + cooldown) {
            return;
        }

        if (isShrink) {
            Blow();
        } else {
            Shrink();
        }

        lastActionTime = Time.time;
    }

    public bool IsShrinked()
    {
        return isShrink;
    }
}
