using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject startButton;
    public GameObject levelSelection;

    void Start()
    {
        
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        levelSelection.SetActive(true);
    }

    public void LoadLevel1()
    {
        // Load level 1
        SceneManager.LoadScene("Level1");
    }

    public void LoadLevel2()
    {
        // Load level 1
        SceneManager.LoadScene("Level2");
    }

    public void LoadLevel3()
    {
        // Load level 1
        SceneManager.LoadScene("Level3");
    }
}
