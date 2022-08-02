using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityModifier;
    [SerializeField] private GameOver gameOver;
    private bool _isGrounded;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        _isGrounded = true;
    }

    private void Update()
    {
        if (gameOver.gameOver) return;
        if (_isGrounded && Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) _isGrounded = true;
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        _isGrounded = false;
    }
}