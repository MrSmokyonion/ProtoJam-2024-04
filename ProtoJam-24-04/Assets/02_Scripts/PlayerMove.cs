using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 10f;

    private Rigidbody playerRb;
    private Transform holdPos;
    private Transform leftHand;
    private Transform rightHand;
    private SkeletonAnimation SkeletonAnimation;
    private TrackEntry trackEntry;
    private List<SkeletonAnimation> Ske;

    private Vector3 dir = Vector3.zero;


    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        holdPos = GameObject.Find("HoldPosition").transform;
        leftHand = GameObject.Find("LeftHand").transform;
        rightHand = GameObject.Find("RightHand").transform;

        SkeletonAnimation = GetComponent<SkeletonAnimation>();
    }
    // Start is called before the first frame update
    void Start()
    {
        holdPos.position = rightHand.position;

    }

    private void Update()
    {

        //SkeletonAnimation.AnimationState.Update(Time.deltaTime);
    }

    void FixedUpdate()
    {


        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");

        dir = dir.normalized;
        if (dir.x > 0) //의자 드는 방향
        {
            holdPos.position = rightHand.position;
        }
        else if (dir.x < 0)
        {
            holdPos.position = leftHand.position;
        }

        playerRb.velocity = dir * moveSpeed;
        //transform.LookAt(transform.position + dir);

        trackEntry = SkeletonAnimation.AnimationState.SetAnimation(0, "Idle", true);

    }
}


