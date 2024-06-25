using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        get { return this.category; }
        set { this.category = value; }
    }

    public float Strength
    {
        get { return this.strength; }
        set { this.strength = value; }
    }

    public float Weight
    {
        get { return this.weight; }
        set { this.weight = value; }
    }
}
