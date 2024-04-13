using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private void Awake() {
        SoundManager.Initialize();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // We will call this function when the user presses escape
    void Quit() 
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
