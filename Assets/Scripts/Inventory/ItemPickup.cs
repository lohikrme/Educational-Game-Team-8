using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemPickup : MonoBehaviour
{
    public ItemData item;
    private bool PlayerClose;


    private void Start() 
    {
        PlayerClose = false;
    }
    void Pickup()
    {
        InventoryController.Instance.Add(item);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerClose = true;
    }

    private void OnTriggerExit(Collider other) 
    {
        PlayerClose = false;
    }

    void Update() {
        if(PlayerClose && Input.GetKeyDown(KeyCode.F))
        {
            Pickup();
            InventoryController.Instance.ListItems();
            
            
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("moi");
            
        }
        
    }
}
