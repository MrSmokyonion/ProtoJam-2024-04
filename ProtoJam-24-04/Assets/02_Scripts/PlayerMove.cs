using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    Vector3 dir;
    CharacterController cc;

    public float rotSpeed = 1.0f;
    public float speed = 6f;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cc.isGrounded)
        {
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");

            dir = new Vector3(h, 0, v) * speed;

            if (dir != Vector3.zero)
            {
                if (Mathf.Sign(transform.forward.x) != dir.x || Mathf.Sign(transform.forward.z) != dir.z)
                {
                    transform.Rotate(0, 1, 0);
                }
                transform.rotation = Quaternion.Euler(0, Mathf.Atan2(h, v) * Mathf.Rad2Deg, 0);
                //transform.forward = Vector3.Lerp(transform.forward, dir, rotSpeed * Time.deltaTime);
            }

        }

        dir.y += Physics.gravity.y * Time.deltaTime;
        cc.Move(dir * Time.deltaTime);
    }

    //private Rigidbody playerRb;
    //private Vector3 dir = Vector3.zero;

    //private float moveSpeed = 10f;
    //private float rotSpeed = 10f;


    //// Start is called before the first frame update
    //void Start()
    //{
    //    playerRb = GetComponent<Rigidbody>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    dir.x = Input.GetAxis("Horizontal");
    //    dir.z = Input.GetAxis("Vertical");
    //    dir.Normalize();
    //}

    //private void FixedUpdate()
    //{
    //    if (dir != Vector3.zero)
    //    {
    //        if (Mathf.Sign(transform.forward.x) != dir.x || Mathf.Sign(transform.forward.z) != dir.z)
    //        {
    //            transform.Rotate(0, 1, 0);
    //        }
    //        transform.forward = Vector3.Lerp(transform.forward, dir, rotSpeed * Time.deltaTime);
    //    }

    //    playerRb.velocity = (dir * moveSpeed);
    //}
}
