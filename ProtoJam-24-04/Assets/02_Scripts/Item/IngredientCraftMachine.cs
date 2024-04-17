using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientCraftMachine : MonoBehaviour
{
    public Item targetItem; //재료 가공 기계가 입력받을 아이템의 종류를 지정.
    public GameObject outputItem;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Items"))
        {
            if(other.GetComponent<GrabableItem>().item.type == targetItem.type)
            {
                Destroy(other.gameObject);
                StartCoroutine(OnStartCraftIngredient());
            }
        }
    }

    IEnumerator OnStartCraftIngredient()
    {
        yield return null;

        float _timer = 0f;
        float _timerLimit = 3f;
        while(true)
        {
            _timer += Time.deltaTime;
            if(_timer > _timerLimit)
            {
                break;
            }
            yield return null;
        }
        Instantiate(outputItem);
        yield return null;
    }
}
