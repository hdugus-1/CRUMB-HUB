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

        //rb.velocity = new Vector3(0, 0, speed);
        
        rb.velocity = new Vector3(Mathf.Cos(spaceshipRotation.rotation.z + Mathf.PI/2) * speed, 0,speed * Mathf.Sin(spaceshipRotation.rotation.z + Mathf.PI/2));
        Debug.Log(spaceshipRotation.rotation.z);
        

        //Mathf.Cos(spaceshipRotation.rotation.z + 90
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
