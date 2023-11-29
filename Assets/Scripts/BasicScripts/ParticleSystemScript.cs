using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemScript : MonoBehaviour
{

    public GameObject particlesystems;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SmokeVisibilityCheck());

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SmokeVisibilityCheck()
    {
        while (true)
        {
            if (GlobalVariables.oilFireIsOn || GlobalVariables.electricFireIsOn)
            {
                MakeSmokeVisible();
            }
            else
            {
                MakeSmokeInvisible();
            }

            yield return new WaitForSeconds(0.1f); // update variable only every 0.1 second
        }



        void MakeSmokeInvisible()
        {
            foreach (Transform child in particlesystems.transform)
            {
                Renderer renderer = child.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.enabled = false;
                }
            }
        }

        void MakeSmokeVisible()
        {
            foreach (Transform child in particlesystems.transform)
            {
                Renderer renderer = child.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.enabled = true;
                }
            }
        }
    }
}
