using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveScript : MonoBehaviour
{
    public string interactMessage = "Paina F asettaaksesi kannen";
    public bool charAtStove = false;
    public GameObject player;
    public GameObject Stove;
    public float interactionDistance = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        // change interactionDistance variable here
        interactionDistance = 2.4f;

        // start CharAtStove()
        StartCoroutine(CharAtStove());

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

    // Update is called once per frame
    void Update()
    {
       // if (charAtStove && Input.GetKeyDown(KeyCode.F))
        //   Debug.Log("Tuli sammutettu");
    }
}
