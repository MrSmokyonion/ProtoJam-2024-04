using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform holdPos;
    public GameObject holdTrigger;

    private GameObject heldObj;
    private Rigidbody heldObjRb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            CheckTrigger();
        }
    }

    private void CheckTrigger()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 10f);

        foreach (Collider collider in colliders)
        {

            if (collider.gameObject.CompareTag("canPickUp"))
            {
                Debug.Log("Check");
                if (heldObj == null)
                {
                    heldObj = collider.gameObject;
                    Pickup();
                }
            }

        }
    }

    private void Pickup()
    {
        heldObjRb = heldObj.GetComponent<Rigidbody>();
        heldObjRb.isKinematic = true;
        heldObj.transform.position = holdPos.position;
        heldObjRb.transform.parent = holdPos.transform;
    }

    
}
