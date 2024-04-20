using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class ResultChairLoader : MonoBehaviour
{
    [Header("Variable")]
    public Transform cameraPos;
    public float distanceBetweenChairs = 7f;
    private int selectedIndex = 0;
    public int ResultChairCount;
    private Vector3 targetPos;
    private float cameraMoveSpeed = 3f;
    public List<ChairScaleController> chairScaleControllers;

    [Header("Result Chair Prefabs")]
    public List<GameObject> chairPrefabs;

    private ResultData resultData;

    private void Start()
    {
        resultData = ResultData.Instance();
        ResultChairCount = resultData.chairs.Count;

        SpawnResultChair();
        targetPos = GetIndexPosition(0);
    }

    private void Update()
    {
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
        Vector3 _target = new Vector3(7f * _index, 14f, -10.2f);
        return _target;
    }

    public void SpawnResultChair()
    {
        for(int i = 0; i < ResultChairCount; i++)
        {
            Vector3 _spawnPos = Vector3.zero;
            _spawnPos.x += distanceBetweenChairs * i;

            GameObject _target = null;
            Chair.ChairType _type = resultData.chairs[i].type;
            switch(_type) 
            {
                case Chair.ChairType.Bench:     _target = chairPrefabs[0]; break;
                case Chair.ChairType.Master:    _target = chairPrefabs[1]; break;
                case Chair.ChairType.Log:       _target = chairPrefabs[2]; break;
                case Chair.ChairType.Circle:    _target = chairPrefabs[3]; break;
                case Chair.ChairType.Rattan:    _target = chairPrefabs[4]; break;
                case Chair.ChairType.Design:    _target = chairPrefabs[5]; break;
                case Chair.ChairType.School:    _target = chairPrefabs[6]; break;
                case Chair.ChairType.WorkSpace: _target = chairPrefabs[7]; break;
                case Chair.ChairType.Wodden:    _target = chairPrefabs[8]; break;
                case Chair.ChairType.ArmChair:  _target = chairPrefabs[9]; break;
                case Chair.ChairType.Sofa:      _target = chairPrefabs[10]; break;
                case Chair.ChairType.Kingdom:   _target = chairPrefabs[11]; break;
            }

            GameObject _obj = Instantiate(_target, _spawnPos, Quaternion.identity);
            chairScaleControllers.Add(_obj.GetComponent<ChairScaleController>());
        }
        //yield return new WaitForSeconds(2f);
        chairScaleControllers[0].bigger = true;
        resultData.DestroyResultData();
    }
}
