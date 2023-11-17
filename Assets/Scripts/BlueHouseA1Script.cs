
// this script locates at Scene -> BlueHouse -> BlueHouseA1
// this is a helper script to help the main script called CharAtBlueHouse

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BlueHouseA1Script : MonoBehaviour
{
    // if the 'Player' enters the area, charAtA1 becomes true
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GlobalVariables.charAtA1 = true;
        }
    }

    // if the 'Player' leaves the area, charAtA1 becomes false
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            {
                GlobalVariables.charAtA1 = false;
            }
    }
 
}
