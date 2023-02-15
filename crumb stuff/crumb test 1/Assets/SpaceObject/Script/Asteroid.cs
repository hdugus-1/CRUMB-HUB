using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject goldPrefab;
    
    public float speed = 10.0f;
    public int health = 100;
    

    public void TakeDamage (int damage)
    {
        health -= damage;
        if(health <= 0) 
        { 
            Die(); 
        }
       
    }
    
    public void Die()
    {
        Destroy(gameObject);
        Instantiate(goldPrefab, transform.position, transform.rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody otherRigidBody = collision.rigidbody;
        if(collision.gameObject.CompareTag("Spaceship"))
        {
            Debug.Log("You're Dead");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity= new Vector3(0,0,-speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
