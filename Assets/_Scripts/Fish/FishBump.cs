using UnityEngine;
using System.Collections;

public class FishBump : MonoBehaviour
{
    public AudioClip collisionAudioClip;
    public float bumpInterval = 1.0f;
    private float lastBump;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && Time.time > lastBump + bumpInterval) {
            GetComponent<AudioSource>().PlayOneShot(collisionAudioClip, 0.3f);
            lastBump = Time.time;
        }
    }
}
