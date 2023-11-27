using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndTextScript : MonoBehaviour
{
    private bool isVisible = true;

    // Start is called before the first frame update
    void Start()
    {
        // Alustetaan objekti näkymättömiin alussa
        SetObjectVisibility(!isVisible);
        // Kuunnellaan ElectricityFireScript määriteltyä tapahtumaa
        ElectricityFireScript.OnEndTextStateChanged += HandleEndTextStateChanged;
    }

    void HandleEndTextStateChanged(bool isEndTextActive)
    {
        // Kun ElectricityFireScriptissä tapahtuu muutos, päivitetään näkyvyys
        isVisible = isEndTextActive;
        SetObjectVisibility(isVisible);
    }

    // Funktio, joka asettaa objektin näkyvyyden
    void SetObjectVisibility(bool visible)
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = visible;
        }
        else
        {
            gameObject.SetActive(visible);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
