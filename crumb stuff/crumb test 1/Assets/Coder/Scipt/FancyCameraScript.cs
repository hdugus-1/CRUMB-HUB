using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FancyCameraScript : MonoBehaviour
{
    public CinemachineVirtualCamera newFancyCam;
    private float CameraFOVDefaultValue;
    private float OffsetVavlue = 5.0f;


    private void Start()
    {
        CameraFOVDefaultValue = newFancyCam.m_Lens.FieldOfView;
    }

    private void Update()
    {
        //newFancyCam.m_Lens.FieldOfView= 80;

        if (spaceshipController.SpaceShipSpeed >= OffsetVavlue)
            newFancyCam.m_Lens.FieldOfView = (spaceshipController.SpaceShipSpeed/4) + CameraFOVDefaultValue;
        //print(spaceshipController.SpaceShipSpeed);
        print(newFancyCam.m_Lens.FieldOfView);
        
    }


}
