using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityFireScript : MonoBehaviour
{
    public float interactionDistance = 3.5f;
    public bool charAtElectricityFire = false;
    public GameObject player;
    public string interactMessage = "Paina F laukaistaksesi vesitäytteisen sammuttimen";
    public static event System.Action<bool> OnFireStateChanged;
    public static event System.Action<bool> OnEndTextStateChanged;

    // Start is called before the first frame update
    void Start()
    {
        // start coroutine
        StartCoroutine(CharAtElectricityFire());

    }

    IEnumerator CharAtElectricityFire()
    {
        while (true)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance <= interactionDistance && GlobalVariables.charAtBlueHouse)
            {
                charAtElectricityFire = true;
            }
            else
            {
                charAtElectricityFire = false;
            }
            yield return new WaitForSeconds(0.1f); // update variable only every 0.1 second
        }
    }
    // here we bring the message to player, if lid is chosen from inventory
    void OnGUI()
    {
        if (charAtElectricityFire && GlobalVariables.fireextinguisherOnHand)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 200, 50), interactMessage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if "F" key is pressed
        if (charAtElectricityFire && Input.GetKeyDown(KeyCode.F) && GlobalVariables.fireextinguisherOnHand && GlobalVariables.electricity == false)
        {
            // Toggle the Electricity fire on/off
            ToggleFire(!gameObject.activeSelf);

        }
        else if (charAtElectricityFire && Input.GetKeyDown(KeyCode.F) && GlobalVariables.fireextinguisherOnHand && GlobalVariables.electricity == true)
        {
            //if electric is on, kill player and end game
            // Set the object active/inactive
            gameObject.SetActive(false);
            // Send happening, let listeners know about change
            OnEndTextStateChanged?.Invoke(false);
        }
    }
    public void ToggleFire(bool turnOn)
    {
        // Set the object active/inactive
        gameObject.SetActive(turnOn);
        // Send happening, send state to listeners
        OnFireStateChanged?.Invoke(turnOn);
    }
}
