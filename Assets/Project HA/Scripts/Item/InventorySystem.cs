using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventorySystem : MonoBehaviour
{
    [SerializeField]
    private List<InventoryItem> weapons = new List<InventoryItem>();
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

    /*
    void SampleFunction()
    {
        // GameMaster ��ũ��Ʈ�� ����ϰ��� �ϴµ�
        // �׷����� �ش� ��ũ��Ʈ�� ����ִ� ���ӿ�����Ʈ ã��
        // ������Ʈ ã������ �ȿ� ����ִ� GameMaster ��ũ��Ʈ�� �����ؼ�
        // GameMaster ��ũ��Ʈ �ȿ� �ִ� �͵��� �� �̿��ϰ� ���� �ǵ� �̷��� �ʹ� ������
        GameObject gameMasterObject =  GameObject.Find("HA.GameMaster");
        GameMaster gameMasterComp = gameMasterObject.GetComponent<GameMaster>();
        gameMasterComp.fx_Level = 1;
        gameMasterComp.MasterVolume(100);

        // GameMaster ��ũ��Ʈ ������ �̹� GameMaster Ÿ���� static ���� instance �� �����Ǿ� �ְ�
        // �̸� �ٷ� ������ �� �ִ�
        GameMaster.instance.fx_Level = 1;
        GameMaster.instance.MasterVolume(100);
    }
    */

    public InventorySystem()
    {
        ClearInventory();
    }

    public void ClearInventory()
    {
        weapons.Clear();
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
            case BaseItem.ItemCategory.WEAPON:
                weapons.Add(item);
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
            case BaseItem.ItemCategory.WEAPON:
                weapons.Remove(item);
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

/*
 done :    ������ ������ �ִϸ��̼�(��ü ���̾� ����ũ ����, �ִϸ��̼� �̺�Ʈ Ÿ�̹� ��������Ʈ) , 
	���� ź��-���� ������ UI, ��ũ��Ʈ ���� 
	��ݽ� �� �߻� ���� ���
	�Ѿ� �¾��� �� ������ ����Ʈ
	
	������ �� ���� �κ��丮 ���̽� ��ũ��Ʈ �۾� ��
	�κ��丮 UI �ӽ� �۾� ��(�׸��� ���̾ƿ�, ���콺 ��ũ��)

to do until next week : ������ �κ��丮 �ϼ�(UI�� ������ ���� ǥ�ñ���)
                        �ð��Ǹ� ������ȯ �ý��� �����(������, ����, īŸ�� ��)

������ �ϰ� ���� �� : ��ų ����(�ִϸ��̼�, ��ų �ߵ� �� ������ ���� �����, ��Ÿ��)
		             �� ���� �� AI
		             ���� ����
	                 ĳ���� ����ġ �ý���
                     ���� �ý���(�κ��丮�� ����)

wepapon currenwea �ְ� ������

 => currentWeapon
 => weaponToEquip

1�� ���⿡�� 2������� ����
currnetWeapon (1��) => holster => holsterFinished? => weaponToEquip != null => Equip�ϴ� ��ǽ���
		            => (weaponToEquip = 2�� ����)			                => 2�� ���� ������
 */
