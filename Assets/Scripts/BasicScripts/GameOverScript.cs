// this script locates in mainscene - CarPark

using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class NewBehaviourScript : MonoBehaviour
{

    // make game over texts here
    public TMP_Text GameWonText;
    public TMP_Text GameLostText;
    public TMP_Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        GameWonText.enabled = false;
        GameLostText.enabled = false;
        ScoreText.enabled = false;

        StartCoroutine(CheckIfGameOver());
    }

    IEnumerator CheckIfGameOver()
    {
        while (true)
        {

            // if player is dead
            if (GlobalVariables.charIsDead == true)
            {
                Debug.Log("player died and game is lost");
                GameLostText.enabled = true;

                Time.timeScale = 0;

                // summon death animation
                

            } 

            // if fires are extinguished and player is alive:
            else if (!GlobalVariables.electricFireIsOn && !GlobalVariables.oilFireIsOn && !GlobalVariables.charIsDead ) 
            {
                Debug.Log("game is won");
                GameWonText.enabled = true;
                ScoreText.text = "Your score is: " + Timer.elapsedTime; // this time no global variable but from timer class
                ScoreText.enabled = true;

                Time.timeScale = 0;
            }
            yield return new WaitForSeconds(0.02f);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
