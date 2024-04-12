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

        transform.position += dir * moveSpeed * Time.deltaTime;

        //if (Input.GetButtonUp("Horizontal"))
        //{

        //    playerRb.velocity = new Vector3(0, playerRb.velocity.y, playerRb.velocity.z);
        //}
        //if (Input.GetButtonUp("Vertical"))
        //{

        //    playerRb.velocity = new Vector3(playerRb.velocity.x, playerRb.velocity.y, 0);
        //}

        //var h = Input.GetAxis("Horizontal");
        //        var v = Input.GetAxis("Vertical");

        //        dir = new Vector3(h, 0, v) * speed;
    }

    private void FixedUpdate()
    {
        if (dir != Vector3.zero) //임시회전
        {
            if (Mathf.Sign(transform.forward.x) != dir.x || Mathf.Sign(transform.forward.z) != dir.z)
            {
                transform.Rotate(0, 1, 0);
            }
            transform.forward = Vector3.Lerp(transform.forward, dir, rotSpeed * Time.deltaTime);
        }

        

        //playerRb.velocity = (dir * moveSpeed);
    }

}
