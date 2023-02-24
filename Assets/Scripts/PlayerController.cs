using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Сила прыжка")] [SerializeField]
    private float JumpForce;

    int counterJump = 0;

    private Animator playerAnim;
    private Rigidbody playerRb;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound, crashSound;
    public AudioSource playerAudio;

    private bool isOnGround = true;

    public bool GameOver;
    public float gravityModifier;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isOnGround || counterJump < 2) && !GameOver)
        {
            counterJump++;
            playerAudio.PlayOneShot(jumpSound, 1);
            playerRb.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
            isOnGround = false;
            // if (counterJump == 1)
            // {
            //     playerAnim.Stop("Jumping");
            // }
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            counterJump = 0;
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerAudio.PlayOneShot(crashSound, 1);
            explosionParticle.Play();
            GameOver = true;
            Debug.Log("GameOver!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            dirtParticle.Stop();
        }
    }
}