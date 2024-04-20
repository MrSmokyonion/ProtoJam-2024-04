using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientCraftMachine : MonoBehaviour
{
    public Transform shootDirection;

    [Header("Item type Vars")]
    public Item targetItem; //재료 가공 기계가 입력받을 아이템의 종류를 지정.
    public GameObject outputItemPrefabs;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Items"))
        {
            if (other.GetComponent<GrabableItem>().item.type == targetItem.type)
            {
                Item.ItemType _type = other.GetComponent<GrabableItem>().item.type;
                GameManager.Instance().RemoveItemOnce(_type);
                Destroy(other.transform.parent.gameObject);
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
        ShootItems();
        yield return null;
    }

    private void ShootItems()
    {
        GameObject _target = outputItemPrefabs;
        if (_target == null)
        {
            return;
        }

        GameObject _obj = Instantiate(_target, shootDirection.position, Quaternion.identity);
        Rigidbody _rigid = _obj.GetComponent<Rigidbody>();
        Vector3 dir = shootDirection.forward;
        dir.Normalize();
        _rigid.velocity = dir * 5f;
    }
}
