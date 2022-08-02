using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private GameOver gameOver;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) gameOver.gameOver = true;
    }
}