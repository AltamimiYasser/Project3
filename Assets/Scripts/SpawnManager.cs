using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePreface;
    [SerializeField] private float minSpawnDelay;
    [SerializeField] private float maxSpawnDelay;
    [SerializeField] private GameOver gameOver;

    private Vector3 _spawnPosition;

    private void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    // ReSharper disable once FunctionRecursiveOnAllPaths
    private IEnumerator SpawnObstacles()
    {
        if (gameOver.gameOver) yield break;

        var randomDelay = GetRandomDelay();

        yield return new WaitForSeconds(randomDelay);
        SpawnObstacle();

        StartCoroutine(SpawnObstacles());
    }

    private void SpawnObstacle()
    {
        _spawnPosition = new Vector3(20, 0, 0);
        Instantiate(obstaclePreface, _spawnPosition, obstaclePreface.transform.rotation);
    }

    private float GetRandomDelay()
    {
        return Random.Range(minSpawnDelay, maxSpawnDelay);
    }
}