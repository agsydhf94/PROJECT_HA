using HA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public CharacterBase characterBase;
    public GameObject ItemMenu;
    public GameObject EquipmentMenu;
    public ItemSlot[] itemSlot;
    public EquipmentSlot[] equipmentSlot;

    public ItemSO[] itemSOs;

    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            ItemMenuUI();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            EquipmentUI();
        }
    }

    private void ItemMenuUI()
    {
        if (ItemMenu.activeSelf)
        {
            Time.timeScale = 1;
            ItemMenu.SetActive(false);
            EquipmentMenu.SetActive(false);
        }

        else
        {
            Time.timeScale = 0;
            ItemMenu.SetActive(true);
            EquipmentMenu.SetActive(false);
        }
    }

    private void EquipmentUI()
    {
        if (EquipmentMenu.activeSelf)
        {
            Time.timeScale = 1;
            ItemMenu.SetActive(false);
            EquipmentMenu.SetActive(false);
        }

        else
        {
            Time.timeScale = 0;
            ItemMenu.SetActive(false);
            EquipmentMenu.SetActive(true);
        }
    }


    private void Awake()
    {
        characterBase = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterBase>();
    }



    public bool UseItem(string itemName)
    {
        for (int i = 0; i < itemSOs.Length; i++)
        {
            if (itemSOs[i].itemName == itemName)
            {
                bool usable = itemSOs[i].UseItem();
                return usable;
            }
            
        }
        return false;
    }


    public int AddItem(string itemName, GameObject itemObject, int quantity, Sprite itemSprite, string itemDescription, ItemType itemType)
    {
        if(itemType == ItemType.consumable)
        {
            for (int i = 0; i < itemSlot.Length; i++)
            {
                if (itemSlot[i].isFull == false && itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0)
                {
                    int leftOverItems = itemSlot[i].AddItem(itemName, itemObject, quantity, itemSprite, itemDescription, itemType);
                    if (leftOverItems > 0)
                    {
                        leftOverItems = AddItem(itemName, itemObject, leftOverItems, itemSprite, itemDescription, itemType);

                    }
                    return leftOverItems;
                }
            }
            return quantity;
        }
        else
        {
            for (int i = 0; i < equipmentSlot.Length; i++)
            {
                if (equipmentSlot[i].isFull == false && equipmentSlot[i].itemName == itemName || equipmentSlot[i].quantity == 0)
                {
                    int leftOverItems = equipmentSlot[i].AddItem(itemName, itemObject, quantity, itemSprite, itemDescription, itemType);
                    if (leftOverItems > 0)
                    {
                        leftOverItems = AddItem(itemName, itemObject, leftOverItems, itemSprite, itemDescription, itemType);

                    }
                    return leftOverItems;
                }
            }
            return quantity;
        }



    }

    public void DeselectAllSlots()
    {
        for(int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
        for (int i = 0; i < equipmentSlot.Length; i++)
        {
            equipmentSlot[i].selectedShader.SetActive(false);
            equipmentSlot[i].thisItemSelected = false;
        }
    }

    
}

public enum ItemType
{
    consumable,
    head,
    body,
    arm,
    legs,
    Rifle,
    Handgun,
    none,
};
