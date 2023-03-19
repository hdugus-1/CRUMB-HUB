using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FancyCameraScript : MonoBehaviour
{
    public CinemachineVirtualCamera newFancyCam;
    private float CameraFOVDefaultValue;
    private float OffsetValue = 6.0f;
    static public bool playerIsDead;
    [SerializeField] private CinemachineImpulseSource impulseSource;

    private void Awake()
    {
        playerIsDead = false;
    }

    private void Start()
    {
        CameraFOVDefaultValue = newFancyCam.m_Lens.FieldOfView;
        impulseSource.GenerateImpulse(new Vector3(1f, 0, 1f));

    }

    private void Update()
    {
        if(spaceshipController.SpaceShipSpeed > OffsetValue)
        {
            newFancyCam.m_Lens.FieldOfView = (spaceshipController.SpaceShipSpeed - OffsetValue)/3.0f + CameraFOVDefaultValue;
        }

        if(Input.GetKeyUp(KeyCode.P)) 
        {
            CameraShake();
        }


        if (playerIsDead)
            CameraShake();
    }

    private void CameraShake()
    {
        impulseSource.GenerateImpulse();
        print("called");

    }

}
