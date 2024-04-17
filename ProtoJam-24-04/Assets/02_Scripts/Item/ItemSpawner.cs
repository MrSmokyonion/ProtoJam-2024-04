using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public GameObject targetObj;

    float timer;

    private void Start()
    {
        timer = 0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > 1f) 
        {
            timer = 0f;
            Vector3 _temp = GetRandomPositionBetweenTwoVector();
            Instantiate(targetObj, _temp, Quaternion.identity);
        }
    }


    Vector3 GetRandomPositionBetweenTwoVector()
    {
        Vector3 result = Vector3.zero;
        result.x = Random.Range(pos1.position.x, pos2.position.x);
        result.y = Random.Range(pos1.position.y, pos2.position.y);
        result.z = Random.Range(pos1.position.z, pos2.position.z);
        return result;
    }
}
