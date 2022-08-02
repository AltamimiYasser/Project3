using UnityEngine;

public class BackgroundRepeater : MonoBehaviour
{
    private float _halfWay;
    private Vector3 _startPosition;

    private void Start()
    {
        _halfWay = GetComponent<BoxCollider>().size.x / 2.0f;
        _startPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position.x < _startPosition.x - _halfWay) transform.position = _startPosition;
    }
}