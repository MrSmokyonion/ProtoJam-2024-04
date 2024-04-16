using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class Machine : MonoBehaviour
{
    public ReciepeTable reciepeTable;
    public Item[] ingredients;
    public int ingredientsCount;


    private void Start() {
        ingredients = new Item[3];
        ingredientsCount = 0;

        Chair chair = reciepeTable.SearchReciepe(ingredients);
        Debug.Log(chair.type.ToString());
    }

    public void AddItemToIngredientsArray(Item _item)
    {
        ingredients[ingredientsCount] = _item;
        ingredientsCount++;

        if(ingredientsCount >= 3)
        {
            CreateChair();
        }
    }

    public void CreateChair()
    {
        Chair result;
        result = reciepeTable.SearchReciepe(ingredients);
        
        if(result.type == Chair.ChairType.none)
        {
            //테이블에서 의자 찾기 실패 했을 때
        }
        //테이블에서 의자 찾기 성공 했을 때
    }
}
