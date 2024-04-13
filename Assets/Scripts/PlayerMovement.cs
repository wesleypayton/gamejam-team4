using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public float footstepThreshold = 0.1f; // Velocity threshold for playing footstep sound
    private bool isWalking = false; // Flag to track if the player is walking


    [Header("Audio")]
    public AudioClip jump;
    public AudioClip walk;
    private AudioSource audioSource;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        // Get the AudioSource component attached to the player GameObject
        audioSource = GetComponent<AudioSource>();

        // Check if the AudioSource component is found
        if (audioSource == null)
        {
            // If AudioSource component is missing, add it
            audioSource = gameObject.AddComponent<AudioSource>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        //ground check
        grounded = Physics.Raycast(transform.position,Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();

        //handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        // Check if the player is grounded and moving
        if (grounded && rb.velocity.magnitude > footstepThreshold)
        {
            if (!isWalking)
            {
                isWalking = true;
                PlayFootstepSound();
            }
            
        }
        else
        {
            if (isWalking)
            {
                isWalking = false;
                StopFootstepSound();
            }
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //when to jump
        if(Input.GetKeyDown(jumpKey) && grounded) 
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        //calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        //on ground
        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        //in air
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    // Method to play the footstep sound
    private void PlayFootstepSound()
    {
        if (walk != null && audioSource != null)
        {
            audioSource.clip = walk;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    // Method to stop the footstep sound
    private void StopFootstepSound()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a ground object (you may need to adjust the tag or layer)
        if (collision.gameObject.CompareTag("trampoline"))
        {
            // Play the landing sound
            if (jump != null && audioSource != null)
            {
                audioSource.PlayOneShot(jump);
            }
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    private void Jump()
    {
        //reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        //play jump sound
        audioSource.PlayOneShot(jump);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}
