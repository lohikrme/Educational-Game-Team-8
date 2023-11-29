// this script locates mainscene - bluehouse - tvtable

using System.Collections;
using UnityEngine;

public class ElectricityFireScript : MonoBehaviour
{
    public float interactionDistance = 4f;
    public bool charAtTV;
    public GameObject player;
    public GameObject tvTable;
    public GameObject electricFire;
    public string interactMessage = "Paina F laukaistaksesi vesitäytteisen sammuttimen";
    public string interactMessage2 = "Television tulipalo on sammutettu!";

    // Start is called before the first frame update
    void Start()
    {
        interactionDistance = 2f;
        charAtTV = false;
        interactMessage = "Paina F laukaistaksesi vesitäytteisen sammuttimen";
        interactMessage2 = "Television tulipalo on sammutettu!";

        MakeElectricFireVisible(); // at the start of game make electric fire always visible

        // start coroutine
        StartCoroutine(CheckIfCharAtTV());
        StartCoroutine(HandleEleFireStateChange());

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
        if (charAtTV && GlobalVariables.fireextinguisherOnHand && GlobalVariables.electricFireIsOn)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 200, 50), interactMessage);
        }
        else if (charAtTV && !GlobalVariables.electricFireIsOn)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 200, 50), interactMessage2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // CHECK IF PLAYER SPRAYS WATER ON TV AFTER ELE IS OFF - FIRE WILL EXTINGUISH
        if (charAtTV && Input.GetKeyDown(KeyCode.F) && GlobalVariables.fireextinguisherOnHand && GlobalVariables.electricity == false)
        {
            GlobalVariables.electricFireIsOn = false;
            MakeElectricFireInvisible(); // use this here, because time freeze so fast otherwise method has no time to react
            Debug.Log("Putting out fire with water extinguisher");
            // possibly summon some kind of waterspray animation?

        }

        // CHECK IF PLAYER SPRAYS WATER WHILE ELE STILL ON - FIRE EXPLOSION, GAME LOST
        else if (charAtTV && Input.GetKeyDown(KeyCode.F) && GlobalVariables.fireextinguisherOnHand && GlobalVariables.electricity == true)
        {
            // summon electricFireExplosion
            GlobalVariables.currentHealth = 0;
            Debug.Log("Causing electric fire explosion");
        }
    }

    IEnumerator HandleEleFireStateChange()
    {
        while (true)
        {
            if (GlobalVariables.electricFireIsOn)
            {
                MakeElectricFireVisible();
            }
            else
            {
                MakeElectricFireInvisible();
            }
            yield return new WaitForSeconds(0.1f); // update variable only every 0.1 second
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

    void MakeElectricFireVisible()
    {
        foreach (Transform child in electricFire.transform)
        {
            Renderer renderer = child.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = true;
            }
        }
    }
}
