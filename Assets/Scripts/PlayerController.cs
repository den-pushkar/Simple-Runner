using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    private MoveLeft movingScript;

    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;

    private float jumpForce = 500;
    private float gravityModifier = 1.5f;
    private bool isOnGround = true;
    public bool onPosition = false;
    public bool gameOver;
    private bool doubleJump;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        movingScript = GameObject.Find("Background").GetComponent<MoveLeft>();
        Physics.gravity *= gravityModifier; 
    }

    void Update()
    {
        Jump();
        StartMove();

        if (movingScript.dashActive == true)
        {
          playerAnim.speed = 3;
        } else
        {
            playerAnim.speed = 1;
        }

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            doubleJump = false;
            isOnGround = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !doubleJump && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            doubleJump = true;
        }
    }
   
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }

    void StartMove()
    {
        if (transform.position.x < 0)
        {
            transform.Translate(Vector3.forward * 0.1f);
           
        }
        else
        {
            playerAnim.SetFloat("Speed_f", 0.6f);
            onPosition = true;
        }
    }
      
 
   
}
