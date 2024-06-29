using HA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HA
{
    public class Interaction_Item : MonoBehaviour, IInteractable
    {

        // public InventoryItem inventoryItem;


        public string Key => "ItemBox." + gameObject.GetHashCode();

        public string Message => "Pick Up";

        public void Interact()
        {
            // to do : Add item to inventory
            InventoryItem myItem = GetComponent<InventoryItem>();
            // myItem.CopyInventoryItem(inventoryItem);


            // �κ��丮�� ������ �߰�
            GameMaster.instance.inventory.AddItem(myItem);

            // ȭ��󿡼� ������ ���� �� UI���� ����
            Destroy(gameObject);
            InteractionUI.Instance.RemoveInteractionData(this);
        }
    }
}
