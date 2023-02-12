using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.InputSystem;

public class TargetBallMovement : MonoBehaviour
{
    public float speed = 5f;
    public Joint root;
    public Joint end;
    private Vector2 handPUS;
    private PlayerInput playerinput;
    private Controls playercontrols;
    public Rigidbody rigidbody;


    private void Awake()
    {
        playerinput = GetComponent<PlayerInput>();
        playercontrols = new Controls();
    }


    private void OnEnable()
    {
        playercontrols.Enable();
    }

    private void OnDisable()
    {
        playercontrols.Disable();
    }

    public void OnSteer(InputAction.CallbackContext context)
    {

        handPUS = context.ReadValue<Vector2>();
    }

    void Update()
    {
        float horizontal = handPUS.x;
        float vertical = handPUS.y;

        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
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
