using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody playerRb;
    private Vector3 dir = Vector3.zero;

    private float moveSpeed = 10f;
    private float rotSpeed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        dir.Normalize();
    }

    private void FixedUpdate()
    {
        if (dir != Vector3.zero)
        {
            if (Mathf.Sign(transform.forward.x) != dir.x || Mathf.Sign(transform.forward.z) != dir.z)
            {
                transform.Rotate(0, 1, 0);
            }
            transform.forward = Vector3.Lerp(transform.forward, dir, rotSpeed * Time.deltaTime);
        }

        playerRb.velocity = (dir * moveSpeed);
    }
}
