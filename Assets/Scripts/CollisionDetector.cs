using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private GameOver gameOver;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;
    [SerializeField] private AudioClip crashSound;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) dirtParticle.Play();

        if (!collision.gameObject.CompareTag("Obstacle")) return;

        dirtParticle.Stop();
        explosionParticle.Play();
        _audioSource.PlayOneShot(crashSound);

        gameOver.gameOver = true;
    }
}