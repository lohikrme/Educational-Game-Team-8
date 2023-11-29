// this script locates at mainscene - blue house - fusebox - fuses

using System.Collections;
using UnityEngine;

public class FusesScript : MonoBehaviour
{

    public GameObject fuses; // these are the fuses


    // Start is called before the first frame update
    void Start()
    {

        // no need to make fuses visible at the start of game - they are automatically depending on if GlobalVariables.electricity is on or off


        // make fuses visible or invisible depending on if electricity is on
        StartCoroutine(HandleElectricStateChanged()); 
    }


    // when electricity is on, make the fuses visible. when ele is off, make them invisible.
    // notice using renderer - using it means this script will run even during invisibility
    // must use foreach to use renderer for the child objects
    IEnumerator HandleElectricStateChanged()
    {
        while (true)
        {

            foreach (Transform child in fuses.transform)
            {
                Renderer renderer = child.GetComponent<Renderer>();
                if (GlobalVariables.electricity == true)
                {
                    if (renderer != null)
                    {
                        renderer.enabled = true;
                    }
                    else
                    {
                        child.gameObject.SetActive(true);
                    }
                }
                else if (GlobalVariables.electricity == false)
                {
                    if (renderer != null)
                    {
                        renderer.enabled = false;
                    }
                    else
                    {
                        child.gameObject.SetActive(false);
                    }
                }

                yield return new WaitForSeconds(0.1f); // update variable only every 0.1 second

            }
        }
    }

}