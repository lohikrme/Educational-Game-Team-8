using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LidOnTheStoveScript : MonoBehaviour
{

    private bool isVisible = false;

    void Start()
    {
        // Object visible at beginning
        SetObjectVisibility(isVisible);
        // Listening what is happening in oilFireScript
        OilFireScript.OnFireStateChanged += HandleFireStateChanged;
    }

    void HandleFireStateChanged(bool isFireActive)
    {
        isVisible = !isFireActive;
        SetObjectVisibility(isVisible);
    }

    // Function, which sets if object is visible
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