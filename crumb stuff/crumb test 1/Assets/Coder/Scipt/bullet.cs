using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
public float speed=500.0f;
Rigidbody rb;


private void Awake() {
    rb=GetComponent<Rigidbody>();
}

public void project(Vector3 direction){
    rb.AddForce(direction* this.speed);
    Destroy(this.gameObject,5f);
}






}