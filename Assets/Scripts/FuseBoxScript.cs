using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class FuseBoxScript : MonoBehaviour
{
    public string interactMessage1 = "Paina F irrottaaksesi sulakkeet...";
    public string interactMessage2 = "Paina F laittaaksesi sulakkeet takaisin...";
    public bool charAtFuseBox = false;
    public GameObject player;
    public GameObject fuseBox;
    public float interactionDistance = 2.5f;

    void Start()
    {
        // change interactionDistance variable here
        interactionDistance = 2.4f;

        // start CharAtFuseBox()
        StartCoroutine(CharAtFuseBox());
    }


    // this method works next: calculates distance using internal Unity command "Vector3.Distance"
    // if character is enough close to the fuseBox and inside BlueHouse, then charAtFuseBox variable becomes true
    IEnumerator CharAtFuseBox()
    {

        while (true) { 
            float distance = Vector3.Distance(player.transform.position, fuseBox.transform.position);
            if (distance <= interactionDistance && GlobalVariables.charAtBlueHouse)
            {
                charAtFuseBox = true;
            }
            else
            {
                charAtFuseBox = false;
            }
            yield return new WaitForSeconds(0.1f); // update variable only every 0.1 second
        }
    }


    // when key F is pressed, reverse the electricity bool value
    void Update()
    {
        if (charAtFuseBox && Input.GetKeyDown(KeyCode.F))
        {
            if (GlobalVariables.electricity == true) 
            {
                GlobalVariables.electricity = false;
            } 

            else if (GlobalVariables.electricity == false) 
            { 
                GlobalVariables.electricity = true;
            }
        }
    }


    // write a message using GUI.Label() method when character is nearby the fusebox depending if electricity is on or off
    void OnGUI()
    {
        if (charAtFuseBox)
        {
            if (GlobalVariables.electricity == true)
            {
                // message written in Label when player is close and electricity is TURNED ON
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 200, 50), interactMessage1);
            }
            else if (GlobalVariables.electricity == false)
            {
                // message written in Label when player is close and electricity is TURNED OFF
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 200, 50), interactMessage2);

            }
        }
    }
}