using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HA
{
    [Serializable]
    public class InventoryItem : BaseItem
    {
        [SerializeField]
        private ItemCategory category;
        [SerializeField]
        private float strength;
        [SerializeField]
        private float weight;

        public ItemCategory Category
        {
            get { return category; }
            set { category = value; }
        }

        public float Strength
        {
            get { return strength; }
            set { strength = value; }
        }

        public float Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public void CopyInventoryItem(InventoryItem myItem)
        {
            Debug.Log(myItem.Category);
            Category = myItem.Category;
            Description = myItem.Description;
            Name = myItem.Name;
            Strength = myItem.Strength;
            Weight = myItem.Weight;
        }
    }
}

