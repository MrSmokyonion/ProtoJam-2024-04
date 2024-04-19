using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator animator;

    private bool isCarring = false;
    public bool IsCarring { get { return isCarring; } private set { isCarring = value; } }

    string state;
    public Rigidbody getRigid()
    {
        return playerRb;
    }

    private void Awake()
    {
        playerRb = this.GetComponent<Rigidbody>();
        animator = this.transform.GetChild(0).GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        ChangeState(state);
    }

    public void ReceisveState(string target)
    {
        state = target;
    }

    public void ReceisveState(bool _isCarring)
    {
        isCarring = _isCarring;
    }

    private void ChangeState(string target)
    {
        switch(target)
        {
            case "Idle":
                animator.SetBool("isIdle", true);
                animator.SetBool("isMove", false);
                animator.SetBool("isCarring", false);

                Debug.Log("Animation" + target);
                break;
            case "Move":
                animator.SetBool("isIdle", false);
                animator.SetBool("isMove", true);
                animator.SetBool("isCarring", false);
                Debug.Log("Animation" + target);
                break;
            case "Carring":
                animator.SetBool("isIdle", false);
                animator.SetBool("isMove", false);
                animator.SetBool("isCarring", true);
                Debug.Log("Animation" + target);
                break;
        }
    }

}
