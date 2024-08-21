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

    // Slot Data
    [SerializeField]
    private ItemType itemType = new ItemType();

    private Sprite itemSprite;
    private string itemName;
    private string itemDescription;

    private bool slotInUse;

    public void EquipGear(Sprite itemSprite, string itemName, string itemDescription)
    {
        this.itemSprite = itemSprite;
        slotImage.sprite = this.itemSprite;
        slotName.enabled = false;

        this.itemName = itemName;
        this.itemDescription = itemDescription;

        slotInUse = true;
    }
}
