using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class OilFireScript : MonoBehaviour
{
    public float interactionDistance = 3.5f;
    public bool charAtOilFire = false;
    public GameObject player;
    public string interactMessage = "Paina F asettaaksesi kannen";
    public static event System.Action<bool> OnFireStateChanged;
    //public static event Action OnLidLowered;
    //private string characterState = "UnEquip Item";

    void Start()
    {
        // Start CharAtOilFire coroutine
        StartCoroutine(CharAtOilFire());
      // Listening to the lid event
        //KettleLid.OnLidLowered += HandleLidLowered;
    }

    // This will check if char is close to the oil fire and brings the functionality in
    IEnumerator CharAtOilFire()
    {
        while (true)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance <= interactionDistance && GlobalVariables.charAtBlueHouse)
            {
                charAtOilFire = true;
            }
            else
            {
                charAtOilFire = false;
            }
            yield return new WaitForSeconds(0.1f); // update variable only every 0.1 second
        }
    }

// here we bring the message to player, if lid is chosen from inventory
    void OnGUI()
    {
        if (charAtOilFire && GlobalVariables.lidOnHand)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 200, 50), interactMessage);
        }
    }


    void Update()
    {
        // Check if "F" key is pressed
        if (charAtOilFire && Input.GetKeyDown(KeyCode.F) && GlobalVariables.lidOnHand)
        {
            // Toggle the oil fire on/off
            ToggleFire(!gameObject.activeSelf);
         }
    }

    public void ToggleFire(bool turnOn)
    {
        // Set the object active/inactive
        gameObject.SetActive(turnOn);
        // Send happening, send state to listeners
        OnFireStateChanged?.Invoke(turnOn);
        // Olettaen, että sinulla on viittaus InventoryController-instanssiin
        //InventoryController inventoryController = GetComponent<InventoryController>(); // Tämä voi olla erilainen riippuen siitä, miten olet saanut viittauksen InventoryControlleriin

        //// Tarkista, onko viittaus olemassa
        //if (inventoryController != null)
        //{
        //    // Etsi "Lid" inventaariosta
        //    ItemData lidItem = inventoryController.inventory.FirstOrDefault(item => item.itemName == "Lid");

        //    // Tarkista, löydettiinkö "Lid"
        //    if (lidItem != null)
        //    {
        //        // Poista "Lid" inventaariosta
        //        inventoryController.Remove(lidItem);
        //    }
        //}

    }

    //    void HandleLidLowered()
    //    {
    //        // Palaa "UnEquip Item" -tilaan kun kattilan kansi lasketaan
    //        characterState = "UnEquip Item";
    //        Debug.Log("Character state: " + characterState);
    //    }
    //}
    //public class KettleLid : MonoBehaviour
    //{
    //    // Määritellään tapahtuma, joka ilmoittaa kattilan kannen laskemisesta
    //    public static event Action OnLidLowered;

    //    // Täällä tapahtuu kattilan kannen laskeminen
    //    public void LowerLid()
    //    {
    //        //Lasketaan kansi

    //        // Lähetetään tapahtuma ilmoittamaan kattilan kannen laskemisesta
    //        OnLidLowered?.Invoke();
    //    }
}