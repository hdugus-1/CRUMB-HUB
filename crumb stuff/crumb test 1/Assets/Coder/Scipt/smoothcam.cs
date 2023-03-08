using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoothcam : MonoBehaviour
{
    // funny
    public Transform target;

    public Vector3 offset;

    public float smoothing = 0.1f;

    private void Start()
    {
        offset = transform.position - target.position;

    }

    private void LateUpdate()
    {
        smoothfollow();
    }

    public void smoothfollow()
    {
        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + offset, smoothing);
        }
        //transform.LookAt(target);
    }

}
