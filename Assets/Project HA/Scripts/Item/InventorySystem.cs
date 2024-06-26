using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [SerializeField]
    private List<InventoryItem> weapons_Rifle = new List<InventoryItem>();
    [SerializeField]
    private List<InventoryItem> armour = new List<InventoryItem>();
    [SerializeField]
    private List<InventoryItem> clothing = new List<InventoryItem>();
    [SerializeField]
    private List<InventoryItem> health = new List<InventoryItem>();
    [SerializeField]
    private List<InventoryItem> potion = new List<InventoryItem>();

    private InventoryItem selectedWeapon;
    private InventoryItem selectedArmor;

    public InventoryItem Selected_Weapon
    {
        get { return selectedWeapon; }
        set { selectedWeapon = value; }
    }

    public InventoryItem Selected_Armor
    {   
        get { return selectedArmor; }
        set { selectedArmor = value; } 
    }



    public InventorySystem()
    {
        ClearInventory();
    }

    public void ClearInventory()
    {
        weapons_Rifle.Clear();
        armour.Clear();
        clothing.Clear();
        health.Clear();
        potion.Clear();
    }


    // �κ��丮�� �������� �߰��ϴ� �Լ�
    public void AddItem(InventoryItem item)
    {
        switch(item.Category)
        {
            case BaseItem.ItemCategory.WEAPON_RIFLE:
                weapons_Rifle.Add(item);
                break;

            case BaseItem.ItemCategory.ARMOUR:
                armour.Add(item);
                break;

            case BaseItem.ItemCategory.CLOTHING:
                clothing.Add(item);
                break;

            case BaseItem.ItemCategory.HEALTH:
                health.Add(item);
                break;

            case BaseItem.ItemCategory.POTION:
                potion.Add(item);
                break;                
        }
    }


    // �κ��丮���� �������� �����ϴ� �Լ�
    public void DeleteItem(InventoryItem item)
    {
        switch (item.Category)
        {
            case BaseItem.ItemCategory.WEAPON_RIFLE:
                weapons_Rifle.Remove(item);
                break;

            case BaseItem.ItemCategory.ARMOUR:
                armour.Remove(item);
                break;

            case BaseItem.ItemCategory.CLOTHING:
                clothing.Remove(item);
                break;

            case BaseItem.ItemCategory.HEALTH:
                health.Remove(item);
                break;

            case BaseItem.ItemCategory.POTION:
                potion.Remove(item);
                break;
        }
    }
}
