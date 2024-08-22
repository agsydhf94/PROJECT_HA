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
    private Item playerDisplayObject;   // 아바타에 입쳐질 아이템 오브젝트

    // Slot Data
    [SerializeField]
    private ItemType itemType = new ItemType();

    private Sprite itemSprite;  // 인벤토리 메뉴 창에 뜰 아이템 이미지
    private GameObject itemObject;  // 실제로 입혀질 아이템 오브젝트
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
