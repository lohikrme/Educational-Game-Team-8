using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance;
    public List<ItemData> inventory = new List<ItemData>();
    public List<GameObject> InventorySlots;

    public ItemData SelectedItem;

    public string SelectedItemDescription;

    private void Awake() 
    {
        Instance = this;
    }


    public void Add(ItemData item)
    {
        inventory.Add(item);
    }

    public void Remove(ItemData item)
    {
        inventory.Remove(item);
    }

    public void ListItems()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            var item = inventory[i];
            var uiItems = InventorySlots[i];
            var image = uiItems.transform.Find("ItemIcon").GetComponent<Image>();
            var text = uiItems.transform.Find("ItemName").GetComponent<TMP_Text>();

            Debug.Log(image);
            Debug.Log(text);
            text.text = item.itemName;
            image.sprite = item.icon;


        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            try{
                SelectedItem = inventory[0];
            } catch (ArgumentOutOfRangeException){
                SelectedItemDescription = "You dont have anything in inventory.";
            }

        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            try{
                SelectedItem = inventory[1];
            } catch (ArgumentOutOfRangeException){
                SelectedItemDescription = "You only have 1 item in inventory";
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            try{
                SelectedItem = inventory[2];
            } catch (ArgumentOutOfRangeException){
                SelectedItemDescription = "You only have 1 item in inventory";
            }
        }
    }
}

