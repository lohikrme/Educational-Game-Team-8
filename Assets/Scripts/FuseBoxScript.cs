using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class FuseBoxScript : MonoBehaviour
{
    public string interactMessage1 = "Paina F irrottaaksesi sulakkeet.";
    public string interactMessage2 = "Paina F laittaaksesi sulakkeet takaisin.";
    public float interactDistance = 5f;
    private bool isPlayerInRange = false;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            if (GlobalVariables.electricity == true) 
            {
                GlobalVariables.electricity = false;
                Debug.Log("Sähkö on laitettu pois päältä!");
            } 

            else if (GlobalVariables.electricity == false) 
            { 
                GlobalVariables.electricity = true;
                Debug.Log("Sähkö on laitettu päälle!");
            }
        }
    }

    void OnGUI()
    {
        if (isPlayerInRange)
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerArmature")
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlayerArmature")
        {
            isPlayerInRange = false;
        }
    }
}