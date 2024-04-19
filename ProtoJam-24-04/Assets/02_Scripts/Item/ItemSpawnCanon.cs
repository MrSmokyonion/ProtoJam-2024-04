using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnCanon : MonoBehaviour
{
    public Transform ShootPos;
    public GameObject projectile;
    public float jumpMultiple = 1f;
    public float jumpPower = 3f;

    [Header("Item Count Var")]
    private int spawned_IronIngot = 0;
    private int spawned_Log = 0;
    private int spawned_Cloth = 0;
    private int spawned_IronPiece = 0;
    private int spawned_WoodenPiece = 0;
    public int MAX_IronIngot = 5;
    public int MAX_Log = 5;
    public int MAX_Cloth = 5;
    public int MAX_IronPiece = 5;
    public int MAX_WoodenPiece = 5;

    [Header("Item Prefabs")]
    public GameObject pre_IronIngot;
    public GameObject pre_Log;
    public GameObject pre_Cloth;
    public GameObject pre_IronPiece;
    public GameObject pre_WoodenPiece;
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
            float _jumpMultiple = UnityEngine.Random.Range(0.5f, jumpMultiple);

            GameObject _obj = Instantiate(projectile, ShootPos.position, Quaternion.identity);
            Rigidbody _rigid = _obj.GetComponent<Rigidbody>();
            Vector3 dir = ShootPos.position - transform.position;
            dir.Normalize();
            _rigid.velocity = dir * jumpPower * _jumpMultiple;
        }
    }

    public GameObject SelectRandomItemToSpawn()
    {
        GameObject _obj;
        


        do
        {
            Item.ItemType type = (Item.ItemType)(UnityEngine.Random.Range(0, Enum.GetNames(typeof(Item.ItemType)).Length + 1));

            //TODO
            switch (type)
            {
                case Item.ItemType.IronIngot:    break;
                case Item.ItemType.Log:          break;
                case Item.ItemType.Cloth:        break;
                case Item.ItemType.IronPiece:    break;
                case Item.ItemType.WoodenPiece:  break;
                default: continue;
            }

            switch (type)
            {
                case Item.ItemType.IronIngot: break;
                case Item.ItemType.Log: break;
                case Item.ItemType.Cloth: break;
                case Item.ItemType.IronPiece: break;
                case Item.ItemType.WoodenPiece: break;
                default: continue;
            }
        } while (true);
        
        

        return _obj;
    }
}
