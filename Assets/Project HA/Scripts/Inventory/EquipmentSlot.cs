using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HA
{
    public class EquipmentSlot : MonoBehaviour, IPointerClickHandler
    {
        // Item data
        public string itemName;
        public int quantity;
        public Sprite itemSprite;
        public GameObject itemObject;
        public bool isFull;
        public string itemDescription;
        public Sprite emptySprite;
        public ItemType itemType;



        [SerializeField]
        private Image itemImage;

        // Equipped Slots
        public EquippedSlot headSlot;
        public EquippedSlot bodySlot;
        public EquippedSlot armSlot;
        public EquippedSlot legsSlot;
        public EquippedSlot rifleSlot;
        public EquippedSlot handgunSlot;



        public GameObject selectedShader;
        public bool thisItemSelected;

        private InventoryManager inventoryManager;

        private void Start()
        {
            // inventoryManager = GameObject.Find("HA.InventoryUI").GetComponent<InventoryManager>();
            inventoryManager = GameObject.FindGameObjectWithTag("InventoryUI").GetComponent<InventoryManager>();
        }

        public int AddItem(string itemName, GameObject itemObject, int quantity, Sprite itemSprite, string itemDescription, ItemType itemType)
        {
            // Check to see if the slot if already full
            if (isFull)
            {
                return quantity;
            }

            // update item type
            this.itemType = itemType;

            // update Name
            this.itemName = itemName;

            // update Image
            this.itemSprite = itemSprite;
            itemImage.sprite = itemSprite;

            // update ItemObject
            this.itemObject = itemObject;

            // update Description
            this.itemDescription = itemDescription;

            // update Quantity
            this.quantity = 1;
            isFull = true;
            return 0;

        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                OnLeftClick();
            }
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                OnRightClick();
            }
        }

        public void OnLeftClick()
        {
            if (thisItemSelected)
            {
                EquipGear();

            }
            else
            {
                inventoryManager.DeselectAllSlots();
                selectedShader.SetActive(true);
                thisItemSelected = true;
            }
        }

        private void EquipGear()
        {
            if(itemType == ItemType.head)
            {
                headSlot.EquipGear(itemSprite, itemObject, itemName, itemDescription);
            }
            if (itemType == ItemType.body)
            {
                bodySlot.EquipGear(itemSprite, itemObject, itemName, itemDescription);
            }
            if (itemType == ItemType.arm)
            {
                armSlot.EquipGear(itemSprite, itemObject, itemName, itemDescription);
            }
            if (itemType == ItemType.legs)
            {
                legsSlot.EquipGear(itemSprite, itemObject,  itemName, itemDescription);
            }
            if (itemType == ItemType.Rifle)
            {
                rifleSlot.EquipGear(itemSprite, itemObject, itemName, itemDescription);
            }
            if (itemType == ItemType.Handgun)
            {
                handgunSlot.EquipGear(itemSprite, itemObject, itemName, itemDescription);
            }

            EmptySlot();
        }

        private void EmptySlot()
        {
            itemImage.sprite = emptySprite;
            isFull = false;
        }

        public void OnRightClick()
        {
            GameObject itemToDrop = new GameObject(itemName);
            Item newItem = itemToDrop.AddComponent<Item>();
            newItem.quantity = 1;
            newItem.itemName = itemName;
            newItem.itemImage = itemSprite;
            newItem.itemDescription = itemDescription;

            SpriteRenderer sr = itemToDrop.AddComponent<SpriteRenderer>();
            sr.sprite = itemSprite;
            sr.sortingOrder = 5;
            sr.sortingLayerName = "Ground";

            itemToDrop.AddComponent<BoxCollider>();

            itemToDrop.transform.position = GameObject.FindWithTag("Player").transform.position
                + new Vector3(0.5f, 0, 0);
            itemToDrop.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);



            // Item Subtraction

            this.quantity -= 1;
            if (this.quantity <= 0)
            {
                EmptySlot();
            }
        }
    }
}

