using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpipenSpin : MonoBehaviour
{
    public float spinSpeed = 50f;

    void Start()
    {
        
    }

    void Update()
    {
        // Rotate the GameObject around the y-axis
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }
}
