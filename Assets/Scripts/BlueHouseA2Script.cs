
// this script locates at Scene -> BlueHouse -> BlueHouseA2"
// this is a helper script for CharAtBlueHouse

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BlueHouseA2Script : MonoBehaviour
{

    // if the 'Player' enters the area charAtA2 becomes true
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            GlobalVariables.charAtA2 = true;
        }
    }


    // if the 'Player' leaves the area charAtA2 becomes false
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GlobalVariables.charAtA2 = false;
        }
    }

}
