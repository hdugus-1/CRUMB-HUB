using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 20.0f;
    public Transform objectRotation;
    public int dmg = 20;
    public Rigidbody rb;
    public Rigidbody spaceshipRb;


    void Start()
    {
        objectRotation = GameObject.FindGameObjectWithTag("GunBase").transform;
        spaceshipRb = GameObject.FindGameObjectWithTag("Spaceship").GetComponent<Rigidbody>();

        if (objectRotation == null)
        {
            Debug.LogWarning("FirePoint not found!");
            return;
        }
        Vector3 direction = (objectRotation.position - transform.position).normalized;
        
        
        rb.velocity = new Vector3(Mathf.Cos(-Mathf.PI/180*(objectRotation.rotation.eulerAngles.y) + Mathf.PI/2) * speed + spaceshipRb.velocity.x, 0,speed * Mathf.Sin(-Mathf.PI/180*(objectRotation.rotation.eulerAngles.y) + spaceshipRb.velocity.y + Mathf.PI / 2));
        
    }
    private void Update()
    {
        objectRotation = GameObject.FindGameObjectWithTag("FirePoint").transform;
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

    private void OnCollisionEnter(Collision other) {
        Destroy(this.gameObject);
    }

}
