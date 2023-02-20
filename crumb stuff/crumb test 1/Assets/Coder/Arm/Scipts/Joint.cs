using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint : MonoBehaviour
{
    public Joint m_child;
    public Joint GetChild() { return m_child; } 

    public void Rotate (float m_angle)
    {
        transform.Rotate(Vector3.forward * m_angle);
    }

}
