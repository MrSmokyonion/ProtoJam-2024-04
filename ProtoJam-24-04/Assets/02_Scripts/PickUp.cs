using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform holdPos;
    public float throwForce = 30f;
    public float reboundForce = 10f;

    private Rigidbody playerRb;
    private GameObject heldObj;
    private Rigidbody heldObjRb;
    private Vector3 searchSize = new Vector3(0.9f, 0.5f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        heldObj = null;
        playerRb = GetComponent<Rigidbody>();
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

    private void CheckTrigger() //�� �� �ִ� ������ Ž��
    {
        Collider[] colliders = Physics.OverlapBox(holdPos.position, searchSize);

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

    private void Pickup() //���
    {
        heldObjRb = heldObj.GetComponent<Rigidbody>();
        heldObjRb.isKinematic = true;
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), GetComponent<Collider>(), true);
        heldObj.transform.position = holdPos.position;
        heldObjRb.transform.parent = holdPos.transform;
    }

    private void DropObject() //��������
    {
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), GetComponent<Collider>(), false);
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null;
        heldObjRb.AddForce(transform.forward * throwForce, ForceMode.Impulse); //������ ������
        playerRb.AddForce(transform.forward * reboundForce * -1, ForceMode.Impulse); //�÷��̾� �ݵ�
        heldObj = null;

    }
}
