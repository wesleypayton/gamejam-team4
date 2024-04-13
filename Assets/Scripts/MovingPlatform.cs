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

    private Vector3 targetPos; // The current target position
    private Vector3 lastPosition; // The last recorded position of the platform
    private Vector3 platformVelocity; // Track platform veloicty


    void Start()
    {
        // Set the initial target position to the end position
        targetPos = endPos.position;

        lastPosition = transform.position;
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

    void OnCollisionStay(Collision collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            // Calculate platform's velocity since the last frame
            platformVelocity = (transform.position - lastPosition) / Time.deltaTime;

            // Set player's velocity to platform's velocity
            playerRigidbody.velocity = platformVelocity;

            print($"player: {playerRigidbody.velocity} + platform: {platformVelocity}");

            // Update the last platform position for the next frame
            lastPosition = transform.position;
        }
    }
}