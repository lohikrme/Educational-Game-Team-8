using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private string interactMessage;

    [SerializeField] TextMeshProUGUI timerText;
    public static float elapsedTime;

    private void Start()
    {
        interactMessage = "Voi ei! Talosi on tulessa! Poimi nopeasti esineitä (painamalla F) jotta voit sammuttaa tulipalon!";
        elapsedTime = 0; // at the start of game elapsed time must awlays be 0
    }


    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void OnGUI()
    {
        if (elapsedTime <= 10f)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 200, 50), interactMessage);
        }
    }
}
