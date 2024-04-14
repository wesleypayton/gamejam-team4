using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public SeverityLevel severity;

    public enum SeverityLevel
    {
        Low,
        Medium,
        High
    }

    void Start()
    {
        // Start player at low severity
        severity = SeverityLevel.Low;

        // Start bee severity timer
        StartCoroutine(IncreaseSeverityRoutine());
    }

    // Update is called once per frame
    void Update()
    {
		
    }

    // This coroutine increases severity level every set time interval
    IEnumerator IncreaseSeverityRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(15f); // Wait for 20 seconds
            IncreaseSeverity();
        }
    }

    public void IncreaseSeverity()
    {
        print("Severity Increased: " + severity.ToString());
        // Increment severity level
        switch (severity)
        {
            case SeverityLevel.Low:
                severity = SeverityLevel.Medium;
                // Change bee particles to medium density

                break;
            case SeverityLevel.Medium:
                severity = SeverityLevel.High;
                // Change bee particles to high density density

                break;
            case SeverityLevel.High:
                // Already at the highest severity level, do not increase

                break;
            default:
                break;
        }
    }
    
    // Decrease severity to low when contacting flower station
    public void DecreaseSeverity()
    {
        StopAllCoroutines();
        severity = SeverityLevel.Low;
        StartCoroutine(IncreaseSeverityRoutine());
    }
}
