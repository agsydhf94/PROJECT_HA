using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]

public class Item : ScriptableObject
{
    // 아이템 이름
    public string itemName;

    // 아이템 이미지
    // Sprite는 캔버스 벗어나도 출력 가능 (image는 캔버스 밖에서 출력 불가)
    public Sprite itemImage;

    public GameObject itemPrefab;

    public string weaponType; // 무기 유형


    public ItemType itemType;
    public enum ItemType
    {
        Equipment,
        Used,
        Ingredient,
        ETC
    }

    
}
