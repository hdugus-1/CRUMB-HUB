using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class targetController : MonoBehaviour
{
    public Transform target;
    Vector2 ballpoint;
    
    float sens = 3;
    private PlayerInput playerinput;
    private Controls playercontrols;

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
        ballpoint = context.ReadValue<Vector2>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x + ballpoint.x * sens, target.position.y, target.position.z + ballpoint.y * sens);

    }
}
