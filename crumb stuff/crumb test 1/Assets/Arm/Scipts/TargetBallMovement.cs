using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class TargetBallMovement : MonoBehaviour
{
    public float speed = 5f;
    public Joint root;
    public Joint end;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;

        float rootToTargetBall = Vector3.Distance(root.transform.position, newPosition);
        float rootToEnd = Vector3.Distance(root.transform.position, end.transform.position);
        float maxDistance = rootToEnd + 1;

        if (rootToTargetBall > maxDistance)
        {
            transform.position = transform.position;
        }
        else
        {
            transform.position = newPosition;
        }
    }
}
