// this script locates mainscene - bluehouse - tvtable

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityFireScript : MonoBehaviour
{
    public float interactionDistance = 4f;
    public bool charAtTV;
    public GameObject player;
    public GameObject tvTable;
    public GameObject electricFire;
    public string interactMessage = "Paina F laukaistaksesi vesitäytteisen sammuttimen";

    // Start is called before the first frame update
    void Start()
    {
        interactionDistance = 4f;
        charAtTV = false;
        interactMessage = "Paina F laukaistaksesi vesitäytteisen sammuttimen";

        // start coroutine
        StartCoroutine(CheckIfCharAtTV());

    }

    IEnumerator CheckIfCharAtTV()
    {
        while (true)
        {
            float distance = Vector3.Distance(player.transform.position, tvTable.transform.position);
            if (distance <= interactionDistance && GlobalVariables.charAtBlueHouse)
            {
                charAtTV = true;
            }
            else
            {
                charAtTV = false;
            }
            yield return new WaitForSeconds(0.1f); // update variable only every 0.1 second
        }
    }


    // here we bring the message to player, if fire extinguisher is chosen from the inventory
    void OnGUI()
    {
        if (charAtTV && GlobalVariables.fireextinguisherOnHand)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 200, 50), interactMessage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // CHECK IF PLAYER SPRAYS WATER ON TV AFTER ELE IS OFF - FIRE WILL EXTINGUISH
        if (charAtTV && Input.GetKeyDown(KeyCode.F) && GlobalVariables.fireextinguisherOnHand && GlobalVariables.electricity == false)
        {
            MakeElectricFireInvisible();
            GlobalVariables.electricFireIsOn = false;
            Debug.Log("Putting out fire with water extinguisher");
            // possibly summon some kind of waterspray animation?

        }

        // CHECK IF PLAYER SPRAYS WATER WHILE ELE STILL ON - FIRE EXPLOSION, GAME LOST
        else if (charAtTV && Input.GetKeyDown(KeyCode.F) && GlobalVariables.fireextinguisherOnHand && GlobalVariables.electricity == true)
        {
            // summon electricFireExplosion
            GlobalVariables.charIsDead = true;
            Debug.Log("Causing electric fire explosion");
        }
    }
    void MakeElectricFireInvisible()
    {
        foreach (Transform child in electricFire.transform)
        {
            Renderer renderer = child.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }
        }
    }
}
