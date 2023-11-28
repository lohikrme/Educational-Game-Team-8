using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckIfGameOver());
    }

    IEnumerator CheckIfGameOver()
    {
        while (true)
        {
            if (GlobalVariables.charIsDead == true)
            {
                Debug.Log("game is lost");
            } 
            else if (GlobalVariables.electricFireIsOn == false && GlobalVariables.oilFireIsOn == false && GlobalVariables.charIsDead == false ) 
            {
                Debug.Log("game is won");
            }
            yield return new WaitForSeconds(0.02f);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
