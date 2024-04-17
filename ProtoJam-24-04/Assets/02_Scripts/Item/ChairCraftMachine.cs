using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class ChairCraftMachine : MonoBehaviour
{
    public ReciepeTable reciepeTableRef;
    public Item[] ingredients;
    public int ingredientsCount;

    private void Start()
    {
        reciepeTableRef = GameManager.Instance().reciepeTable;
        ingredients = new Item[3];
        ingredientsCount = 0;
    }

    public void AddItemToIngredientsArray(Item _item)
    {
        if (ingredientsCount >= 3)
            return;

        ingredients[ingredientsCount] = _item;
        ingredientsCount++;
    }

    public void ClearIngredients()
    {
        System.Array.Clear(ingredients, 0, 2);
        ingredientsCount = 0;
    }

    public bool CheckIngredientsIsFull()
    {
        if(ingredientsCount >= 3)
        {
            return true;
        }
        return false;
    }

    public void CreateChair()
    {
        StartCoroutine(OnStartCraftChair());
    }

    private bool SearchReciepe()
    {
        Chair result;
        result = reciepeTableRef.SearchReciepe(ingredients);
        
        if(result.type == Chair.ChairType.none)
        {
            //테이블에서 의자 찾기 실패 했을 때
            Debug.LogWarning("의자 레시피 데이터 찾기 실패");
            ClearIngredients();
            return false;
        }
        else
        {
            //테이블에서 의자 찾기 성공 했을 때
            GameManager.Instance().AddScore(result);
            ClearIngredients();
            return true;
        }
    }

    IEnumerator OnStartCraftChair()
    {
        yield return null;

        float _timer = 0f;
        float _timerLimit = 3f;
        while (true)
        {
            _timer += Time.deltaTime;
            if (_timer > _timerLimit)
            {
                break;
            }
            yield return null;
        }
        SearchReciepe();
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Items"))
        {
            Destroy(other.gameObject);
            AddItemToIngredientsArray(other.GetComponent<GrabableItem>().item);
            if(CheckIngredientsIsFull())
            {
                CreateChair();
            }
        }
    }
}
