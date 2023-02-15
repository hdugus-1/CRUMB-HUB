using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20.0f;
    public Transform firePoint;
    public int dmg = 20;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 direction = (firePoint.position - transform.position).normalized;
        rb.velocity = direction * speed; 
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
