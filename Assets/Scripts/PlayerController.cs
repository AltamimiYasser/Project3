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
    private int _jumpCount;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        if (gameOver.gameOver)
        {
            _animator.SetBool(DeathB, true);
            _animator.SetInteger(DeathTypeINT, 1);

            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _jumpCount < 2) Jump();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) _jumpCount = 0;
    }

    private void Jump()
    {
        _jumpCount++;
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        _animator.SetTrigger(JumpTrig);
        dirtParticle.Stop();
        _audioSource.PlayOneShot(jumpAudio);
    }
}