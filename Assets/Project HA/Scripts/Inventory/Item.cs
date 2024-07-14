using HA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Item : MonoBehaviour, IInteractable
{
    [SerializeField]
    public string itemName;

    [SerializeField]
    private int quantity;

    [SerializeField]
    private Sprite itemImage;

    [SerializeField]
    private string itemDescription;

    [TextArea]

    private InventoryManager inventoryManager;

    public string Key => "";

    public string Message => "PickUp";

    

    private void Awake()
    {
        inventoryManager = GameObject.Find("HA.InventoryUI").GetComponent<InventoryManager>();
    }

    public void Interact()
    {
        int leftOverItems = inventoryManager.AddItem(itemName, quantity, itemImage, itemDescription);
        if(leftOverItems <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            quantity = leftOverItems;
        }
        // Destroy(gameObject);
    }

    






}
