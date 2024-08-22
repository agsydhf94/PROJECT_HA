using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquippedSlot : MonoBehaviour
{
    // Slot Shape
    [SerializeField]
    private Image slotImage;

    [SerializeField]
    private TMP_Text slotName;

    [SerializeField]
    private Item playerDisplayObject;   // �ƹ�Ÿ�� ������ ������ ������Ʈ

    // Slot Data
    [SerializeField]
    private ItemType itemType = new ItemType();

    private Sprite itemSprite;  // �κ��丮 �޴� â�� �� ������ �̹���
    private GameObject itemObject;  // ������ ������ ������ ������Ʈ
    private string itemName;
    private string itemDescription;

    private bool slotInUse;

    public void EquipGear(Sprite itemSprite, string itemName, string itemDescription)
    {
        // Image update
        this.itemSprite = itemSprite;
        slotImage.sprite = this.itemSprite;
        slotName.enabled = false;

        // Name, Description update
        this.itemName = itemName;
        this.itemDescription = itemDescription;

        // Display image update
        
        

        slotInUse = true;
    }
}
