using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Reciepe
{
    public Item[] items;
    public Chair[] chairs;

    public Reciepe()
    {
        items = new Item[3];
        chairs = new Chair[2];
    }

    public bool CompareIngredients(Item[] _items)
    {
        for(int i = 0; i < 3; i++)
        {
            if(_items[i].type != items[i].type)
            {
                return false;
            }
        }
        return true;
    }
}
