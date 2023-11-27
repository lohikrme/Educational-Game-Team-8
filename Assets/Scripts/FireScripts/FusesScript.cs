using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FusesScript : MonoBehaviour
{

    private bool isVisible = true;
    // Start is called before the first frame update
    void Start()
    {
        // Alustetaan objekti n‰kyv‰ksi alussa
        SetObjectVisibility(isVisible);
        // Kuunnellaan FuseBoxScriptiss‰ m‰‰ritelty‰ tapahtumaa
        FuseBoxScript.OnElectricStateChanged += HandleElectricStateChanged;
    }

    void HandleElectricStateChanged(bool isElectricActive)
    {
        // Kun FuseBoxScriptiss‰ tapahtuu muutos, p‰ivitet‰‰n n‰kyvyys
        isVisible = !isElectricActive;
        SetObjectVisibility(isVisible);
    }

    // Funktio, joka asettaa objektin n‰kyvyyden
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
}