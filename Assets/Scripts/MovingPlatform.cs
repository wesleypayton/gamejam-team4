using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingPlatform : MonoBehaviour
{
    public Transform startPos; // Starting Position
    public Transform endPos; // EndPosition
    public float speed = 1.0f; // Platform Move Speed
    public float arrivalThreshold = 0.1f; // Wiggle room for start/end
    public float jumpForce = 6f;

    private AudioSource audioSource;
    private Vector3 targetPos; // The current target position

    [Header("Audio")]
    private AudioClip jump;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        jump = Resources.Load("Sounds/jump") as AudioClip;
        audioSource.clip = jump;
        audioSource.volume = 0.8f;
        // Set the initial target position to the end position
        targetPos = endPos.position;
    }

    void Update()
    {
        // Move the platform towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // If the platform reaches the target position, switch the target position
        if (Vector3.Distance(transform.position, targetPos) <= arrivalThreshold)
        {
            if (targetPos == startPos.position)
                targetPos = endPos.position;
            else
                targetPos = startPos.position;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            // Set jump velocity
            Vector3 newVelocity = playerRigidbody.velocity;
            newVelocity.y = jumpForce;
            playerRigidbody.velocity = newVelocity;
        }
    }
}