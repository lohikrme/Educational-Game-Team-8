using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    public List<ItemInstance> worldItems;
    public List<ItemInstance> inventory;

    void Start()
    {
        Debug.Log(worldItems);
        Debug.Log(inventory);
    }
}

[System.Serializable]
public class ItemInstance
{
    public ItemData itemType;
    public int type;
    public int fuel;
}

