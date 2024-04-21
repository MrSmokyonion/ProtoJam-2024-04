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
    public MachineTimerUI machineTimerUI;
    public Transform shootDirection;
    public List<GameObject> chairPrefabs;
    public List<GameObject> lightObjectList;

    private bool isMachineRunning;

    private void Start()
    {
        //reciepeTableRef = GameManager.Instance().reciepeTable;
        ingredients = new Item[3];
        ingredientsCount = 0;
        isMachineRunning = false;
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
        isMachineRunning = true;
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
            Debug.Log("Score! >> " + result.type.ToString());

            int _index = (int)(result.type);
            ShootItems(chairPrefabs[_index]);

            return true;
        }
    }

    IEnumerator OnStartCraftChair()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Working);
        yield return null;

        float _timer = 0f;
        float _timerLimit = 3f;
        machineTimerUI.gameObject.SetActive(true);
        machineTimerUI.StartTimer(_timerLimit);
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
        isMachineRunning = false;
        machineTimerUI.gameObject.SetActive(false);
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Complete);
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isMachineRunning) { return; }

        if (other.CompareTag("Items"))
        {
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Putin);

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

    private void ShootItems(GameObject _target)
    {
        if (_target == null)
        {
            return;
        }

        GameObject _obj = Instantiate(_target, shootDirection.position, Quaternion.identity);
        Rigidbody _rigid = _obj.GetComponent<Rigidbody>();
        Vector3 dir = shootDirection.forward;
        dir.Normalize();
        _rigid.velocity = dir * 5f;

        AudioManager.instance.PlaySfx(AudioManager.Sfx.Shipment);
    }
}
