using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20.0f;
    public Transform firePoint;
    public int dmg = 20;
    public Rigidbody rb;



    void Start()
    {
        firePoint = GameObject.FindGameObjectWithTag("FirePoint").transform;
        if (firePoint == null)
        {
            Debug.LogWarning("FirePoint not found!");
            return;
        }
        Vector3 direction = (firePoint.position - transform.position).normalized;
        rb.velocity = new Vector3(0, 0, speed);
    }
    private void Update()
    {
        firePoint = GameObject.FindGameObjectWithTag("FirePoint").transform;
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
