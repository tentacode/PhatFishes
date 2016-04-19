using UnityEngine;

public class MineExploder : MonoBehaviour
{
    public ParticleSystem explosionParticles;
    private bool collided = false;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (collided || other.gameObject.tag == "Sky") {
            return;
        }

        collided = true;

        Explode(other);
    }

    void Explode(Collision2D other)
    {
        GetComponent<AudioSource>().Play();
        explosionParticles.Play();
        GetComponent<Animator>().SetTrigger("Explode");
        Destroy(gameObject, 10);
    }
}
