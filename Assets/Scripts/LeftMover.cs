using UnityEngine;

public class LeftMover : MonoBehaviour
{
    [SerializeField] private MoveSpeed moveSpeed;
    [SerializeField] private GameOver gameOver;

    private void Update()
    {
        if (gameOver.gameOver) return;
        transform.Translate(Vector3.left * (Time.deltaTime * moveSpeed.speed));
    }
}