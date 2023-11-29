// this script locates at mainscene - bluehouse - stove

using System.Collections;
using UnityEngine;

public class OilFireScript : MonoBehaviour
{
    
    public bool charAtStove;
    public GameObject player;
    public GameObject Stove;
    public GameObject lidOfFirePan;
    public GameObject oilFire;
    public float interactionDistance;
    public string interactMessage1;
    public string interactMessage2;
    public string interactMessage3;


    // Start is called before the first frame update
    // use start to make sure messages etc are what is needed instead of dependant on unity editor settings...
    void Start()
    {
        interactMessage1 = "Paina F asettaaksesi kansi!";
        interactMessage2 = "Paina F suihkuttaaksesi vettä!";
        interactMessage3 = "Tuli on sammutettu!";

        charAtStove = false;
        interactionDistance = 2.4f;

        // start CharAtStove() and handleoilfirestatechange methods
        StartCoroutine(CharAtStove());
        StartCoroutine(HandleOilFireStateChange());

    }

    //this will check if char is close to the stove, and brings the functionality in
    IEnumerator CharAtStove()
    {
        while (true)
        {
            float distance = Vector3.Distance(player.transform.position, Stove.transform.position);
            if (distance <= interactionDistance && GlobalVariables.charAtBlueHouse)
            {
                charAtStove = true;
            }
            else
            {
                charAtStove = false;
            }
            yield return new WaitForSeconds(0.1f); // update variable only every 0.1 second
        }
    }

    // Update method affects only oilFireIsOn and GlobalVariables.currentHealth,
    // while visiblity of fire and lid is handled in HandleOilFireStateChange method
    void Update()
    {
        // CHECK IF PLAYER USES LID SUCCESFULLY TO EXTINGUISH THE FIRE
        if (charAtStove && GlobalVariables.lidOnHand && Input.GetKeyDown(KeyCode.F))
        {
            GlobalVariables.oilFireIsOn = false;
            MakeOilFireInvisible(); // use this here, because time freeze so fast otherwise method has no time to react
            Debug.Log("Putting out fire with the lid!");
        }

        // CHECK IF PLAYER DOESNT REALIZE OIL EXPLODES FROM WATER AND DIED FROM THE EXPLOSION - GAME LOST
        else if (charAtStove && GlobalVariables.fireextinguisherOnHand && Input.GetKeyDown(KeyCode.F))
        {
            // KUTSU ÖLJYPALORÄJÄHDYS - GAME OVER LOST
            GlobalVariables.currentHealth = 0;
            Debug.Log("Causing oil fire explosion!");
        }
    }

    void OnGUI()
    {
        if (charAtStove)
        {
            if (GlobalVariables.lidOnHand && GlobalVariables.oilFireIsOn)
            {
                // guide to turn off the fire with the lid
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 200, 50), interactMessage1);
            }
            else if (GlobalVariables.fireextinguisherOnHand && GlobalVariables.oilFireIsOn)
            {
                // guide to spray water with the extinguisher
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 200, 50), interactMessage2);
            }
            else if (!GlobalVariables.oilFireIsOn)
            {
                // tell that the fire has been extinguished!
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 200, 50), interactMessage3);
            }
        }
    }

    // when fire is on, fire must be visible and lid invisible, and the opposite:
    IEnumerator HandleOilFireStateChange()
    {
        while (true)
        {
            if (GlobalVariables.oilFireIsOn)
            {
                makeLidInvisible();
                MakeOilFireVisible(); 
            }
            else
            {
                MakeLidVisible();
                MakeOilFireInvisible();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }


    // this script makes te lid invisible at the start of game
    void makeLidInvisible()
    {
        Renderer renderer = lidOfFirePan.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }
    }


    // this script makes lid visible when character press f and is able to turn off fire
    void MakeLidVisible()
    {
        Renderer renderer = lidOfFirePan.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = true;
        }
    }

    // use this to render flames invisible when fire is turned off
    void MakeOilFireInvisible()
    {
        foreach (Transform child in oilFire.transform)
        {
            Renderer renderer = child.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }
        }
    }

    void MakeOilFireVisible()
    {
        foreach (Transform child in oilFire.transform)
        {
            Renderer renderer = child.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = true;
            }
        }
    }

}
