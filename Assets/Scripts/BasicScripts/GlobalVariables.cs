using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    // ---------------------------------------------------------------
    // ALL GLOBAL VARIABLES ARE STORED HERE
    // ---------------------------------------------------------------



    // CHARACTER INFORMATION

    public static int maxHitpoints = 100;
    public static int hitpoints;

    public static bool charAtA1 = false;
    public static bool charAtA2 = false;
    public static bool charAtBlueHouse = false;

    public static bool charIsDead = false;


    // ITEM INFORMATION

    public static bool fireextinguisherOnHand = false; // InventoryController updates
    public static bool lidOnHand = false; // InventoryController updates
    public static bool phoneOnHand = false; // InventoryController updates
    public static bool fryingpanOnHand = false; // InventoryController updates


    // BLUE HOUSE INFORMATION

    public static bool electricity = true; // FuseBoxScript updates


    // FIRE INFORMATION
    public static bool oilFireIsOn = true; // OilFireScript updates
    public static bool electricFireIsOn = true; // ?? possibly wont be used in final version


}
