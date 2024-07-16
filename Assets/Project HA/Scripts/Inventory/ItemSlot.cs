using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HA
{
    public class ItemSlot : MonoBehaviour, IPointerClickHandler
    {
        // Item data
        public string itemName;
        public int quantity;
        public Sprite itemSprite;
        public bool isFull;
        public string itemDescription;
        public Sprite emptySprite;

        [SerializeField]
        private int maxNumberOfItems;

        // Item Slot
        [SerializeField]
        private TMP_Text quantityText;

        [SerializeField]
        private Image itemImage;


        // Item Description
        public Image itemDescriptionImage;
        public TMP_Text ItemDescriptionNameText;
        public TMP_Text ItemDescriptionText;


        public GameObject selectedShader;
        public bool thisItemSelected;

        private InventoryManager inventoryManager;

        private void Start()
        {
            inventoryManager = GameObject.Find("HA.InventoryUI").GetComponent<InventoryManager>();
        }

        public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
        {
            // Check to see if the slot if already full
            if(isFull)
            {
                return quantity;
            }

            // update Name
            this.itemName = itemName;

            // update Image
            this.itemSprite = itemSprite;
            itemImage.sprite = itemSprite;

            // update Description
            this.itemDescription = itemDescription;

            // update Quantity
            this.quantity += quantity;

            

            
            if(this.quantity >= maxNumberOfItems)
            {
                quantityText.text = maxNumberOfItems.ToString();
                quantityText.enabled = true;
                isFull = true;

                // return the leftovers
                int extraItems = this.quantity - maxNumberOfItems;
                this.quantity = maxNumberOfItems;
                return extraItems;
            }

            // update the quantity text
            quantityText.text = this.quantity.ToString();
            quantityText.enabled = true;

            return 0;

        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if(eventData.button == PointerEventData.InputButton.Left)
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
            if(thisItemSelected)
            {
                bool usable = inventoryManager.UseItem(itemName);
                if(usable)
                {
                    this.quantity -= 1;
                    quantityText.text = this.quantity.ToString();
                    if (this.quantity <= 0)
                    {
                        EmptySlot();
                    }
                }
                
            }
            else
            {
                inventoryManager.DeselectAllSlots();
                selectedShader.SetActive(true);
                thisItemSelected = true;
                ItemDescriptionNameText.text = itemName;
                ItemDescriptionText.text = itemDescription;
                itemDescriptionImage.sprite = itemSprite;
                if (itemDescriptionImage.sprite == null)
                {
                    itemDescriptionImage.sprite = emptySprite;
                }
            }

            
        }

        private void EmptySlot()
        {
            quantityText.enabled = false;
            itemImage.sprite = emptySprite;

            ItemDescriptionNameText.text = "";
            ItemDescriptionText.text = "";
            itemDescriptionImage.sprite = emptySprite;
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
            quantityText.text = this.quantity.ToString();
            if (this.quantity <= 0)
            {
                EmptySlot();
            }
        }
    }
}
