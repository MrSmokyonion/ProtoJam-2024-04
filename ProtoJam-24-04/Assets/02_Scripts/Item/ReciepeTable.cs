using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "ReciepeTable", menuName = "Scriptable Object/Create ReciepeTable")]
public class ReciepeTable : ScriptableObject
{
    public List<Reciepe> reciepes;

    public Chair SearchReciepe(Item[] _items)
    {
        //0.변수 할당
        Reciepe targetReciepe = null;
        Chair result = new Chair();

        //1. 매개변수로 받은 아이템 리스트를 사용해 레시피 탐색
        foreach(Reciepe _reciepe in reciepes)
        {
            if(_reciepe.CompareIngredients(_items))
            {
                targetReciepe = _reciepe;
                break;
            }
        }

        //2. 레시피 못 찾았으면 none 반환
        if(targetReciepe == null)
        {
            result.type = Chair.ChairType.none;
            return result;
        }

        //3. 레시피 찾았으면 chair 랜덤 출력
        //TODO : 찾은 레시피에서 의자 2개 중 1개 선택하도록 랜덤값 추가할 것
        result = targetReciepe.chairs[0];
        return result;
    }
}
