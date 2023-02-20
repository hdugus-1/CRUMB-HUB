using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wardenChase : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float moveSpeed;
    public float Accelspeed;
    public Transform spaceshipPosition;
    public Transform wardenPosition;

    // Start is called before the first frame update
    void Start()
    {
        spaceshipPosition = GameObject.FindGameObjectWithTag("Spaceship").transform;
        wardenPosition = GameObject.FindGameObjectWithTag("Warden").transform;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (spaceshipPosition.position - wardenPosition.position).normalized;
        rigidbody.AddForce(direction*Accelspeed*Time.deltaTime);
        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, 15.0f);
        transform.LookAt(spaceshipPosition, Vector3.up);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody otherRigidBody = collision.rigidbody;
        if (collision.gameObject.CompareTag("Spaceship"))
        {
            SceneManager.LoadScene("LosingScene");

        }
    }
}
