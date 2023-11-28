using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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

            // check which item is selected, and modify GlobalVariables accordingly
            if (SelectedItem.itemName == "Fire extinguisher")
            {
                GlobalVariables.fireextinguisherOnHand = true;
                GlobalVariables.fryingpanOnHand = false;
                GlobalVariables.lidOnHand = false;
                GlobalVariables.phoneOnHand = false;
            }

            else if (SelectedItem.itemName == "Frying pan")
            {
                GlobalVariables.fryingpanOnHand = true;
                GlobalVariables.fireextinguisherOnHand = false;
                GlobalVariables.lidOnHand = false;
                GlobalVariables.phoneOnHand = false;
            }

            else if (SelectedItem.itemName == "Phone")
            {
                GlobalVariables.phoneOnHand = true;
                GlobalVariables.fryingpanOnHand = false;
                GlobalVariables.fireextinguisherOnHand = false;
                GlobalVariables.lidOnHand = false;
            }

            else if (SelectedItem.itemName == "Lid")
            {
                GlobalVariables.lidOnHand = true;
                GlobalVariables.phoneOnHand = false;
                GlobalVariables.fryingpanOnHand = false;
                GlobalVariables.fireextinguisherOnHand = false;
            }

            // Debug.Log("Lid on hand: " + GlobalVariables.lidOnHand);
            // Debug.Log("Fireextinguisher on hand: " + GlobalVariables.fireextinguisherOnHand);
            // Debug.Log("Fryingpan on hand: " + GlobalVariables.fryingpanOnHand);
            // Debug.Log("Phone on hand: " + GlobalVariables.phoneOnHand);


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

        GlobalVariables.lidOnHand = false;
        GlobalVariables.phoneOnHand = false;
        GlobalVariables.fryingpanOnHand = false;
        GlobalVariables.fireextinguisherOnHand = false;
    }
}

