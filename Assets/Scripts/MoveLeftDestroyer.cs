using UnityEngine;

public class MoveLeftDestroyer : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.x < -10) Destroy(gameObject);
    }

    
}