using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public enum ItemType
    {
        none = -1,
        IronIngot = 0,
        Log = 1,
        Cloth = 2,
        IronPiece = 3,
        WoodenPiece = 4
    }

    [SerializeField]
    public ItemType type;

    public Item()
    {
        type = ItemType.none;
    }
}
