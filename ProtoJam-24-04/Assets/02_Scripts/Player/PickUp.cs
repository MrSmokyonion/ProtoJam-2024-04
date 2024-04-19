using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Vector3 searchSize = new Vector3(1.8f, 1f, 2f); //탐색 범위 반
    public float throwForce = 30f;
    public float reboundForce = 10f;

    private Rigidbody playerRb;
    private Transform holdPos;
    private Vector3 throwDir;

    private GameObject heldObj;
    private Rigidbody heldObjRb;


    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        holdPos = GameObject.Find("HoldPosition").transform;

        heldObj = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(playerRb);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerRb.velocity != Vector3.zero)
        {
            throwDir = playerRb.velocity.normalized;

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (heldObj == null)
            {
                SearchItem();
            }
            else
            {
                DropObject();
            }
        }

        //효과음 출력 테스트
        if(Input.GetKeyDown(KeyCode.R))
        {
            AudioManager.instance.PlaySfx(AudioManager.Sfx.hm);
        }
    }

    private void SearchItem() //들 수 있는 아이템 탐색
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, searchSize);

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("canPickUp"))
            {
                Pickup(collider.gameObject);
                break;
            }

        }
    }

    private void Pickup(GameObject _heldObj) //들기
    {
        heldObj = _heldObj;
        heldObjRb = heldObj.GetComponent<Rigidbody>();

        heldObjRb.isKinematic = true;
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), GetComponent<Collider>(), true);
        heldObj.transform.position = holdPos.position;
        heldObjRb.transform.parent = holdPos.transform;

        //animation
        PlayerInfo playerInfo = GetComponent<PlayerInfo>();
        playerInfo.ReceisveState("Carring");
        playerInfo.ReceisveState(true);
    }

    private void DropObject() //던지기
    {
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), GetComponent<Collider>(), false);
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null;
        heldObjRb.AddForce(throwDir * throwForce, ForceMode.Impulse); //아이템 던지기
        playerRb.AddForce(throwDir * reboundForce * -1, ForceMode.Impulse); //플레이어 반동

        heldObj = null;

        //animation
        PlayerInfo playerInfo = GetComponent<PlayerInfo>();
        playerInfo.ReceisveState("Idle");
        playerInfo.ReceisveState(false);
    }
}
