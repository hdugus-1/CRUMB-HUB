using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKManager : MonoBehaviour
{
    public Transform m_cylinder1;
    public Transform m_cylinder2;
    public Joint m_root;
    public Joint m_end;
    public float m_threshold = 0.5f;
    public float m_rate = 5.0f;
    public GameObject m_target;

    float GetDistance(Vector3 _point1, Vector3 _point2)
    {
        return Vector3.Distance(_point1, _point2);
    }

    float CalculateSlope(Joint _joint)
    {
        float delta = 0.001f;
        float distance1 = GetDistance(m_end.transform.position, m_target.transform.position);
        _joint.Rotate(delta);

        float distance2 = GetDistance(m_end.transform.position, m_target.transform.position);
        _joint.Rotate(-delta);

        return (distance2 - distance1) / delta;
    }
    void Update()
    {
      

        //Code for the movement of the end joint to the target
        if (GetDistance(m_end.transform.position, m_target.transform.position) > m_threshold)
        {
            Joint current = m_root;
            while (current != null)
            {
                float slope = CalculateSlope(current);
                current.Rotate(-slope * m_rate);
                current = current.GetChild();
            }
        }
    }
}
