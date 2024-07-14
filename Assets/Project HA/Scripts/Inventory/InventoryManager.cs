using HA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    public bool menuActivated;
    public ItemSlot[] itemSlot;

    /*
    private void Update()
    {
        
        if(Input.GetButtonDown("InventoryMenu") && menuActivated)
        {    
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }

        else if (Input.GetButtonDown("InventoryMenu") && !menuActivated)
        {
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }

    }
    */

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false && itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0)
            {
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                if(leftOverItems > 0)
                {
                    leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription);
                    
                }
                return leftOverItems;
            }
        }
        return quantity;
    }

    public void DeselectAllSlots()
    {
        for(int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }



}
