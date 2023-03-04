using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrols : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public bullet bulletprefab;
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);            
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            shoot();
        }
    }
    public void shoot(){
        bullet bullets=Instantiate(bulletprefab,this.transform.position,this.transform.rotation);
        bullets.project(this.transform.forward);
    }
}