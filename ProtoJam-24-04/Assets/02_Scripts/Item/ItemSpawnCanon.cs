using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnCanon : MonoBehaviour
{
    public Transform ShootPos;
    public float jumpMultiple = 1f;
    public float jumpPower = 3f;

    [Header("Item Count Var")]
    private int spawned_IronIngot = 0;
    private int spawned_Log = 0;
    private int spawned_Cloth = 0;
    public int MAX_IronIngot = 5;
    public int MAX_Log = 5;
    public int MAX_Cloth = 5;

    [Header("Item Prefabs")]
    public GameObject pre_IronIngot;
    public GameObject pre_Log;
    public GameObject pre_Cloth;
    float timer;

    private void Start()
    {
        timer = 0;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > 0.4f)
        {
            timer = 0f;

            ShootItems();
        }
    }

    private void ShootItems()
    {
        float _jumpMultiple = UnityEngine.Random.Range(0.5f, jumpMultiple);

        GameObject _target = SelectRandomItemToSpawn();
        if(_target == null)
        {
            return;
        }

        GameObject _obj = Instantiate(_target, ShootPos.position, Quaternion.identity);
        Rigidbody _rigid = _obj.GetComponent<Rigidbody>();
        Vector3 dir = ShootPos.position - transform.position;
        dir.Normalize();
        _rigid.velocity = dir * jumpPower * _jumpMultiple;
    }

    public GameObject SelectRandomItemToSpawn()
    {
        GameObject _obj = null;

        do
        {
            Item.ItemType type = (Item.ItemType)(UnityEngine.Random.Range(0, Enum.GetNames(typeof(Item.ItemType)).Length + 1 - 2));

            bool restart = false;
            switch (type)
            {
                case Item.ItemType.IronIngot: restart = spawned_IronIngot >= MAX_IronIngot ? true : false; break;
                case Item.ItemType.Log:         restart = spawned_Log >= MAX_Log ? true : false; break;
                case Item.ItemType.Cloth:       restart = spawned_Cloth >= MAX_Cloth ? true : false; break;
                default: break;
            }

            if(restart)
            {
                break;  //무한루프 방지를 위해서...
            }

            switch (type)
            {
                case Item.ItemType.IronIngot:   _obj = pre_IronIngot; spawned_IronIngot++; break;
                case Item.ItemType.Log:         _obj = pre_Log; spawned_Log++; break;
                case Item.ItemType.Cloth:       _obj = pre_Cloth; spawned_Cloth++; break;
                default: Debug.Log("Error"); break;
            }
            break;
        } while (true);

        return _obj;
    }
}
