using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingPlatform : MonoBehaviour
{
    public Transform startPos; // Starting Position
    public Transform endPos; // EndPosition
    public float speed = 1.0f; // Platform Move Speed
    public float arrivalThreshold = 3f; // Wiggle room for start/end

    private Vector3 targetPos; // The current target position

    void Start()
    {
        // Set the initial target position to the end position
        targetPos = endPos.position;
    }

    void Update()
    {
        print($"target: {targetPos}\n current {transform.position}");
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
}
