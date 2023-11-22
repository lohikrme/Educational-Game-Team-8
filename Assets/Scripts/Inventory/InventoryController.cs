using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEditor.UI;
using UnityEditorInternal.VersionControl;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance;
    public List<ItemData> inventory = new List<ItemData>();
    public List<GameObject> InventorySlots;

    public ItemData SelectedItem;

    public TMP_Text SelectedItemUiText;

    public GameObject EquippedItemModel;

    private void Awake() 
    {
        Instance = this;
    }

    private void Start() {
        UnequipItem();

        
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
            EquipItem(0);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipItem(1);
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            EquipItem(2);
        }

    }

    private void EquipItem(int slot)
    {
        try{
                SelectedItem = inventory[slot];
                UnequipItem();
                SelectedItemUiText.text = SelectedItem.description;
                InventorySlots[slot].transform.Find("SelectedIcon").GetComponent<Image>().enabled = true;
                EquippedItemModel.transform.GetChild(SelectedItem.id).gameObject.SetActive(true);
            } catch (ArgumentOutOfRangeException)
            {
              SelectedItemUiText.text = "You dont have anything in that slot.";
            }
    }

    private void UnequipItem()
    {
        foreach(var slot in InventorySlots)
        {
            slot.transform.Find("SelectedIcon").GetComponent<Image>().enabled = false;
        }
        foreach (Transform child in EquippedItemModel.transform)
            child.gameObject.SetActive(false);
    }
}

