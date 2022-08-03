using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static readonly int JumpTrig = Animator.StringToHash("Jump_trig");
    private static readonly int DeathB = Animator.StringToHash("Death_b");
    private static readonly int DeathTypeINT = Animator.StringToHash("DeathType_int");

    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityModifier;
    [SerializeField] private GameOver gameOver;
    [SerializeField] private ParticleSystem dirtParticle;
    [SerializeField] private AudioClip jumpAudio;

    private Animator _animator;
    private AudioSource _audioSource;
    private bool _isGrounded;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
        _isGrounded = true;
    }

    private void Update()
    {
        if (gameOver.gameOver)
        {
            _animator.SetBool(DeathB, true);
            _animator.SetInteger(DeathTypeINT, 1);

            return;
        }

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
        _animator.SetTrigger(JumpTrig);
        dirtParticle.Stop();
        _audioSource.PlayOneShot(jumpAudio);
    }
}