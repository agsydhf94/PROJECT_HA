using HA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Item : MonoBehaviour, IInteractable
{
    [SerializeField]
    public string itemName;

    [SerializeField]
    public int quantity;

    [SerializeField]
    public Sprite itemImage;

    [SerializeField]
    public string itemDescription;

    [TextArea]

    private InventoryManager inventoryManager;

    public ItemType itemType;

    public string Key => gameObject.name;

    public string Message => $"{itemName}";

    

    private void Awake()
    {
        // inventoryManager = GameObject.Find("HA.InventoryUI").GetComponent<InventoryManager>();
        // inventoryManager = InventoryManager.Instance;
        inventoryManager = GameObject.FindGameObjectWithTag("InventoryUI").GetComponent<InventoryManager>();
    }

    public void Interact()
    {
        int leftOverItems = inventoryManager.AddItem(itemName, quantity, itemImage, itemDescription, itemType);
        if(leftOverItems <= 0)
        {
            InteractionUI.Instance.RemoveInteractionData(this);
            Destroy(gameObject);
        }
        else
        {
            quantity = leftOverItems;
        }
        // Destroy(gameObject);
    }

    






}
