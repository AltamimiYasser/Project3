using UnityEngine;

[CreateAssetMenu]
public class GameOver : ScriptableObject
{
    public bool gameOver;

    private void OnEnable()
    {
        gameOver = false;
    }
}