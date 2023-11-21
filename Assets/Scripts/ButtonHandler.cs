using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public GameObject Main;
    public GameObject Highscores;
    public GameObject Credits;

    void Start()
    {
        ShowMain();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ShowHighscores()
    {
        Main.SetActive(false);
        Highscores.SetActive(true);
        Credits.SetActive(false);
    }
    public void ShowCredits()
    {
        Main.SetActive(false);
        Highscores.SetActive(false);
        Credits.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ShowMain()
    {
        Highscores.SetActive(false);
        Credits.SetActive(false);
        Main.SetActive(true);
    }
}
