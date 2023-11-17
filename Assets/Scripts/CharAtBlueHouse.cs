// This script locates at Scene - BlueHouse - FantasyHouse
// This script is used to store information about if the 'Player' locates inside blue house or not.
// It combines information from 2 other scripts (BlueHouseA1 and BlueHouseA2) 
// these other scripts store their data to charAtA1 and charAtA2

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAtBlueHouse : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(CheckIfInsideBlueHouse());
    }

    // this method checks once per 0.1s if the Player is inside the BlueHouse
    IEnumerator CheckIfInsideBlueHouse()
    {

        // logic is that if player is inside either of the areas A1 or A2, then it is inside the BlueHouse
        while (true) { 
            if (GlobalVariables.charAtA1 == true || GlobalVariables.charAtA2 == true) 
            {
                GlobalVariables.charAtBlueHouse = true;
            }

            else
            {
                GlobalVariables.charAtBlueHouse = false;
            }

            yield return new WaitForSeconds(0.1f); // yield requires coroutine to work, pauses the code for 0.1s break
        }
    }
}
