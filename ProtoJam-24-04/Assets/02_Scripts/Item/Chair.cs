using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Chair
{
    public enum ChairType
    {
        none = -1,
        Bench = 0,
        Master = 1,
        Log,
        Circle,
        Rattan,
        Design,
        School,
        WorkSpace,
        Wodden,
        ArmChair,
        Sofa,
        Kingdom
    }

    [SerializeField]
    public ChairType type;

    public Chair()
    {
        type = ChairType.none;
    }
}
