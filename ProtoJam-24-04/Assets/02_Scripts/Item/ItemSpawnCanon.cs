using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnCanon : MonoBehaviour
{
    public Transform ShootPos;
    public GameObject projectile;
    public float jumpMultiple = 1f;
    public float jumpPower = 3f;
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
            float _jumpMultiple = Random.Range(0.5f, jumpMultiple);

            GameObject _obj = Instantiate(projectile, ShootPos.position, Quaternion.identity);
            Rigidbody _rigid = _obj.GetComponent<Rigidbody>();
            Vector3 dir = ShootPos.position - transform.position;
            dir.Normalize();
            _rigid.velocity = dir * jumpPower * _jumpMultiple;
        }
    }
}
