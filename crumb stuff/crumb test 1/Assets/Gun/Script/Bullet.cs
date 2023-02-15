using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 5.0f;
    public Transform spaceshipRotation;
    public int dmg = 20;
    public Rigidbody rb;



    void Start()
    {
        spaceshipRotation= GameObject.FindGameObjectWithTag("Spaceship").transform;
        
        if (spaceshipRotation == null)
        {
            Debug.LogWarning("FirePoint not found!");
            return;
        }
        Vector3 direction = (spaceshipRotation.position - transform.position).normalized;
        
        // transform.rotation.y return quaternion angles and not eulerangles .eulerAngles.y gives normal degree angles
        rb.velocity = new Vector3(Mathf.Cos(-Mathf.PI/180*(spaceshipRotation.rotation.eulerAngles.y) + Mathf.PI/2) * speed, 0,speed * Mathf.Sin(-Mathf.PI/180*(spaceshipRotation.rotation.eulerAngles.y) + Mathf.PI / 2));
        
    }
    private void Update()
    {
        spaceshipRotation = GameObject.FindGameObjectWithTag("FirePoint").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        Asteroid asteroid = other.GetComponent<Asteroid>();
        if (asteroid != null) 
        {
            asteroid.TakeDamage(dmg);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
