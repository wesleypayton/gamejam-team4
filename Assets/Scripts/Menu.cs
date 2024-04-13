using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;

    void Start()
    {
        panel1.SetActive(true);
        panel2.SetActive(false);
    }

    public void LevelSelect()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
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

    public void Back() {
        panel2.SetActive(false);
        panel1.SetActive(true);

    }

    public void LoadMainMenu() 
    {
        // Load Main Menu
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit() 
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif 
        Application.Quit();
    }
}
