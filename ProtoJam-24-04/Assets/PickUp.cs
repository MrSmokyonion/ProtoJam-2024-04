using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform holdPos;
    public GameObject Player;

    private GameObject heldObj;
    private Rigidbody heldObjRb;
    private Vector3 Trigger = new Vector3(0.9f, 0.5f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        heldObj = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (heldObj == null)
            {
                CheckTrigger();
            }
            else
            {
                DropObject();
            }
        }
    }

    private void CheckTrigger() //들 수 있는 아이템 탐색
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, Trigger);

        foreach (Collider collider in colliders)
        {

            if (collider.gameObject.CompareTag("canPickUp"))
            {
                Debug.Log("Check");
                heldObj = collider.gameObject;
                Pickup();

                break;
            }

        }
    }

    private void Pickup() //들기
    {
        heldObjRb = heldObj.GetComponent<Rigidbody>();
        heldObjRb.isKinematic = true;
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), Player.GetComponent<Collider>(), true);
        heldObj.transform.position = holdPos.position;
        heldObjRb.transform.parent = holdPos.transform;
    }

    private void DropObject() //내려놓기
    {
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), Player.GetComponent<Collider>(), false);
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null;
        heldObj = null;
    }
}
