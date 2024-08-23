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

    
    public Sprite itemSprite;  // �κ��丮 �޴� â�� �� ������ �̹���
    public GameObject[] itemObjects;  // ������ ������ ������ ������Ʈ
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
        // ���� ������ ������ ����
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

        // ������ ������Ʈ �迭 �ʱ�ȭ
        itemObjects = new GameObject[attachPoints.Length];

        // �� ���� ����Ʈ�� ������ ����
        for (int i = 0; i < attachPoints.Length; i++)
        {
            itemObjects[i] = Instantiate(itemPrefab, attachPoints[i].position, attachPoints[i].rotation, attachPoints[i]);
        }



        slotInUse = true;
    }
}
