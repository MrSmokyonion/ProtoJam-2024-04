using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using UnityEngine.UIElements;

public class ChairCraftMachine : MonoBehaviour
{
    public ReciepeTable reciepeTableRef;
    public Item[] ingredients;
    public int ingredientsCount;
    public List<GameObject> lightObjectList;

    private void Start()
    {
        //reciepeTableRef = GameManager.Instance().reciepeTable;
        ingredients = new Item[3];
        ingredientsCount = 0;
    }

    public void AddItemToIngredientsArray(Item _item)
    {
        if (ingredientsCount >= 3)
            return;

        ingredients[ingredientsCount] = _item;
        ingredientsCount++;
        UpdateLightObject(ingredientsCount);
    }

    public void UpdateLightObject(int i)
    {
        for (i = 0; i < ingredientsCount; i++)
        {
            lightObjectList[i].gameObject.SetActive(true);
        }
    }
    public void TurnOffAllLightObject()
    {
        for (int i = 0; i < 3; i++)
        {
            lightObjectList[i].gameObject.SetActive(false);
        }
    }

    public void ClearIngredients()
    {
        System.Array.Clear(ingredients, 0, 2);
        ingredientsCount = 0;
        TurnOffAllLightObject();
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
            GameManager.Instance().AddScore(result);  //TODO
            ClearIngredients();
            Debug.Log("Score!");
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
            Item.ItemType _type = other.GetComponent<GrabableItem>().item.type;
            GameManager.Instance().RemoveItemOnce(_type);
            Destroy(other.transform.parent.gameObject);
            AddItemToIngredientsArray(other.GetComponent<GrabableItem>().item);
            if(CheckIngredientsIsFull())
            {
                CreateChair();
            }
        }
    }
}
