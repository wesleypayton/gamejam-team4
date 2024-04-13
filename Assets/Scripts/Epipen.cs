using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Epipen : MonoBehaviour
{
    public float spinSpeed = 50f;
    public GameObject epipenRenderer;
    private AudioSource audioSource;
    private Collider collider;
    private string nextScene;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        collider = GetComponent<Collider>();
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level1":
                nextScene = "Level2";
                break;
            case "Level2":
                nextScene = "level3";
                break;
            case "Level3":
                nextScene = "GameWin";
                break;
        }
    }

    void Update()
    {
        // Rotate the GameObject around the y-axis
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }
    
    void GrabEpipen()
    {
        collider.enabled = false;
        audioSource.Play();
        epipenRenderer.SetActive(false);
        StartCoroutine(CompleteLevel());
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            GrabEpipen();
        }
    }

    IEnumerator CompleteLevel()
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // Load the desired scene
        SceneManager.LoadScene(nextScene);
    }
}