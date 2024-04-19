using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultChairLoader : MonoBehaviour
{
    [Header("Variable")]
    public Transform cameraPos;
    public float distanceBetweenChairs = 7f;
    private int selectedIndex = 0;
    private int ResultChairCount = 5;
    private Vector3 targetPos;
    private float cameraMoveSpeed = 3f;
    public List<ChairScaleController> chairScaleControllers;

    [Header("Result Chair Prefabs")]
    public GameObject ResultChair_WoodChair;

    private void Start()
    {
        SpawnResultChair();
        targetPos = GetIndexPosition(0);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            MoveRight();
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            MoveLeft();
        }

        cameraPos.position = Vector3.Lerp(cameraPos.position, targetPos, Time.deltaTime * cameraMoveSpeed);
    }

    public void MoveRight()
    {
        selectedIndex++;
        selectedIndex = selectedIndex >= ResultChairCount ? ResultChairCount - 1 : selectedIndex;
        chairScaleControllers[selectedIndex].bigger = true;
        chairScaleControllers[selectedIndex - 1].bigger = false;
        targetPos = GetIndexPosition(selectedIndex);
    }

    public void MoveLeft()
    {
        selectedIndex--;
        selectedIndex = selectedIndex < 0 ? 0 : selectedIndex;
        chairScaleControllers[selectedIndex].bigger = true;
        chairScaleControllers[selectedIndex + 1].bigger = false;
        targetPos = GetIndexPosition(selectedIndex);
    }

    private Vector3 GetIndexPosition(int _index)
    {
        Vector3 _target = new Vector3(7f * _index, 8.8f, -5f);
        return _target;
    }

    public void SpawnResultChair()
    {
        for(int i = 0; i < ResultChairCount; i++)
        {
            Vector3 _spawnPos = Vector3.zero;
            _spawnPos.x += distanceBetweenChairs * i;

            GameObject _obj = Instantiate(ResultChair_WoodChair, _spawnPos, Quaternion.identity);
            chairScaleControllers.Add(_obj.GetComponent<ChairScaleController>());
        }
        chairScaleControllers[0].bigger = true;
    }
}
