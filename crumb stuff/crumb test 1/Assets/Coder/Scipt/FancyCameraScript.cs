using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FancyCameraScript : MonoBehaviour
{
    public CinemachineVirtualCamera newFancyCam;
    private float CameraFOVDefaultValue;
    private float OffsetValue = 5.0f;
    private float SecondOffsetValue = 30.0f;



    private void Start()
    {
        CameraFOVDefaultValue = newFancyCam.m_Lens.FieldOfView;
    }

    private void Update()
    {

        if (spaceshipController.SpaceShipSpeed >= OffsetValue && spaceshipController.SpaceShipSpeed <= SecondOffsetValue)
        {
            newFancyCam.m_Lens.FieldOfView = (spaceshipController.SpaceShipSpeed / 4) + CameraFOVDefaultValue;
        }
        else if(spaceshipController.SpaceShipSpeed >= SecondOffsetValue)
        {
            newFancyCam.m_Lens.FieldOfView = (spaceshipController.SpaceShipSpeed / 5) + CameraFOVDefaultValue;
        }

        //print("speed: " + spaceshipController.SpaceShipSpeed);
        //print(newFancyCam.m_Lens.FieldOfView);
        
    }


}
