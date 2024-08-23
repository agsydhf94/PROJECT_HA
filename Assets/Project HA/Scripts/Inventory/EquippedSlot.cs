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

    public Transform[] attachPoints;

    // Slot Data
    [SerializeField]
    private ItemType itemType = new ItemType();

    
    public Sprite itemSprite;  // 인벤토리 메뉴 창에 뜰 아이템 이미지
    public GameObject[] itemObjects;  // 실제로 입혀질 아이템 오브젝트
    public string itemName;
    public string itemDescription;

    private bool slotInUse;

    public void EquipGear(Sprite itemSprite, GameObject itemPrefab, string itemName, string itemDescription)
    {
        // Image update
        this.itemSprite = itemSprite;
        slotImage.sprite = this.itemSprite;
        slotName.enabled = false;

        // Name, Description update
        this.itemName = itemName;
        this.itemDescription = itemDescription;

        // Item equip
        // 기존 장착된 아이템 제거
        if (itemObjects != null)
        {
            foreach (GameObject obj in itemObjects)
            {
                if (obj != null)
                {
                    Destroy(obj);
                }
            }
        }

        // 아이템 오브젝트 배열 초기화
        itemObjects = new GameObject[attachPoints.Length];

        // 각 부착 포인트에 아이템 부착
        for (int i = 0; i < attachPoints.Length; i++)
        {
            itemObjects[i] = Instantiate(itemPrefab, attachPoints[i].position, attachPoints[i].rotation, attachPoints[i]);
        }



        slotInUse = true;
    }
}
