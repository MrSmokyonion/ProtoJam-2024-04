using Spine;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 10f;

    Rigidbody _rigidbody;
    PlayerInfo _playerInfo;

    private bool isFacingRight = true;
    private Transform holdPos;
    private Transform leftHand;
    private Transform rightHand;
    private Vector3 dir = Vector3.zero;

    private void Awake()
    {
        holdPos = GameObject.Find("HoldPosition").transform;
        leftHand = GameObject.Find("LeftHand").transform;
        rightHand = GameObject.Find("RightHand").transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        holdPos.position = rightHand.position;
        _playerInfo = GetComponentInParent<PlayerInfo>();
        _rigidbody = _playerInfo.getRigid();

    }

    private void Update()
    {
        Flip();
    }
    void FixedUpdate()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.z = Input.GetAxisRaw("Vertical");
        dir = dir.normalized;

        if (MathF.Abs(Input.GetAxisRaw("Horizontal")) == 1 || MathF.Abs(Input.GetAxisRaw("Vertical")) == 1)
        {
            if (dir.x > 0)
            {
                holdPos.position = rightHand.position;
            }
            else if (dir.x < 0)
            {
                holdPos.position = leftHand.position;
            }

            if(!_playerInfo.IsCarring)
            {
                _playerInfo.ReceisveState("Move");
            }
        }
        else
        {
            if(!_playerInfo.IsCarring)
                _playerInfo.ReceisveState("Idle");
        }
        //transform.LookAt(transform.position + dir);

        _rigidbody.velocity = dir * moveSpeed;

    }

    private void Flip()
    {
        if (isFacingRight && dir.x < 0f)
        {
            Vector3 temp = this.transform.GetChild(0).localScale;
            temp.x = -0.1f;
            transform.GetChild(0).localScale = temp;
        }
        else if (isFacingRight && dir.x > 0f)
        {
            Vector3 temp = this.transform.GetChild(0).localScale;
            temp.x = 0.1f;
            transform.GetChild(0).localScale = temp;
        }
    }
}


