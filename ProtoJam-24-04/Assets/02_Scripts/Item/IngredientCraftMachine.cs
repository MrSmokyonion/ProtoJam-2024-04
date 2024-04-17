using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientCraftMachine : MonoBehaviour
{
    public Item targetItem; //��� ���� ��谡 �Է¹��� �������� ������ ����.
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
