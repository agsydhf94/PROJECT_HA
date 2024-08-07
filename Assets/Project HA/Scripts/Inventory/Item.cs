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

    public string Key => gameObject.name;

    public string Message => $"{itemName}";

    

    private void Awake()
    {
        // inventoryManager = GameObject.Find("HA.InventoryUI").GetComponent<InventoryManager>();
        inventoryManager = InventoryManager.Instance;
    }

    public void Interact()
    {
        int leftOverItems = inventoryManager.AddItem(itemName, quantity, itemImage, itemDescription);
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
