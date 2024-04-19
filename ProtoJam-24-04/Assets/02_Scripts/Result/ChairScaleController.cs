using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairScaleController : MonoBehaviour
{
    public bool bigger = false;
    public float scaleSpeed = 3f;

    private void Start()
    {
        transform.localScale = Vector3.zero;
    }

    private void Update()
    {
        if (bigger)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * scaleSpeed);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0.5f, 0.5f, 0.5f), Time.deltaTime * scaleSpeed);
        }
    }

}
