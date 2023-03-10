using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FancyCameraScript : MonoBehaviour
{
    public CinemachineVirtualCamera newFancyCam;
    private float CameraFOVDefaultValue;
    private float OffsetValue = 6.0f;
    private float SecondOffsetValue = 30.0f;



    private void Start()
    {
        CameraFOVDefaultValue = newFancyCam.m_Lens.FieldOfView;
    }

    private void Update()
    {
        if(spaceshipController.SpaceShipSpeed > OffsetValue)
        {
            newFancyCam.m_Lens.FieldOfView = (spaceshipController.SpaceShipSpeed - OffsetValue)/3.0f + CameraFOVDefaultValue;
        }

        //print("speed: " + spaceshipController.SpaceShipSpeed);
        //print(newFancyCam.m_Lens.FieldOfView);
        
    }


}
