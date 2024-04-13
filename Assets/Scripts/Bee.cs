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
            yield return new WaitForSeconds(20f); // Wait for 20 seconds
            IncreaseSeverity();
        }
    }

    public void IncreaseSeverity()
    {
        print("Severity Increased" + severity.ToString());
        // Increment severity level
        switch (severity)
        {
            case SeverityLevel.Low:
                severity = SeverityLevel.Medium;
                break;
            case SeverityLevel.Medium:
                severity = SeverityLevel.High;
                break;
            case SeverityLevel.High:
                // Already at the highest severity level, do nothing
                break;
            default:
                break;
        }
    }

    public void DecreaseSeverity()
    {
        // Set severity to lowest level when contacting flower station
        severity = SeverityLevel.Low;
    }
}
