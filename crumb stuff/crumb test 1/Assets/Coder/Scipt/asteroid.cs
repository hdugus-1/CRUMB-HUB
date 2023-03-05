using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    public float size=30.0f;
    public float minsize=20.0f;
    public float maxsize=40.5f;
    public float speed=6.0f;
    public float maxLifeTime=10.0f;
    public float lifeTime=0.0f;
    public float asteroidHP=75f;
    Rigidbody rb;
    public coin coinprefab;


    public float damageReceieved=25f;
   
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


   


    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="bullet"){
           asteroidHP-=damageReceieved;
        }
        if(asteroidHP<=0){
        Destroy(this.gameObject);
       }
       if(asteroidHP<=0 && this.name=="asteroid_gold(Clone)"){
        coin coins=Instantiate(coinprefab,this.transform.position,this.transform.rotation);
        coins.coinDecay();
       }
    }


   


    public void SetTrajectory(Vector3 direction){
        direction.y=0f;
        rb.AddForce(direction *speed*Random.Range(-0.5f, 0.5f),ForceMode.Acceleration);
    }

}
