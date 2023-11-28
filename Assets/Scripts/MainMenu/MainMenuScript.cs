// locates on the other scene - MainMenu - Canvas - Scripts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{

    // main is the area where all buttons are located
    public GameObject Main;
    // area where high scores are written
    public GameObject Highscores;
    // area where credits (maker info) are written
    public GameObject Credits;

    // buttons are needed so when user press button then eventlistener activates a function accordinly
    public Button PlayButton;
    public Button HighscoresButton;
    public Button CreditsButton;
    public Button QuitButton; 


    void Start()
    {
        ShowMain();
        PlayButton.onClick.AddListener(StartGame);
        HighscoresButton.onClick.AddListener(ShowHighscores);
        CreditsButton.onClick.AddListener(ShowCredits);
        QuitButton.onClick.AddListener(QuitGame);
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
    
    public void ShowMain()
    {
        Highscores.SetActive(false);
        Credits.SetActive(false);
        Main.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowMain();
        }
    }
}