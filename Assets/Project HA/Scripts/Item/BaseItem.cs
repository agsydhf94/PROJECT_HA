using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : MonoBehaviour
{
    public enum ItemCategory
    {
        WEAPON = 0,
        ARMOUR = 1,
        CLOTHING = 2,
        HEALTH = 3,
        POTION = 4,
    }

    [SerializeField]
    private string name;

    [SerializeField]
    private string description;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }
}
