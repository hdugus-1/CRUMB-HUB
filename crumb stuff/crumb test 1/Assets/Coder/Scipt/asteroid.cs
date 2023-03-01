using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    public float size=1.0f;
    public float minsize=0.5f;
    public float maxsize=1.5f;
    public float speed=25.0f;
    public float maxLifeTime=10.0f;
    public float lifeTime=0.0f;
    Rigidbody rb;
    
    private void Awake() {
       
        rb=GetComponent<Rigidbody>();
    }
    private void Start() {
        this.transform.eulerAngles=new Vector3(0.0f,0.0f, Random.value * 360.0f);
        this.transform.localScale= Vector3.one * this.size;
        rb.mass=this.size;
    }

    

    private void Update(){
        lifeTime+=Time.deltaTime;
        if((GameObject.FindGameObjectWithTag("Spaceship").transform.position - this.gameObject.transform.position).magnitude <20f){
               lifeTime=0;
            }
       if(lifeTime>=maxLifeTime){
        Destroy(this.gameObject);
       }
     

    }

    

    public void SetTrajectory(Vector3 direction){
        direction.y=0f;
        rb.AddForce(direction * this.speed,ForceMode.Acceleration);
    }
}
