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

    static public GameObject VFXbulletCollided;
    static public GameObject AsteroidExplosion;

    public float damageReceieved=25f;
   
    private void Awake() {
        VFXbulletCollided.SetActive(false);
        AsteroidExplosion.SetActive(false);
        rb=GetComponent<Rigidbody>();
    }
    private void Start() {
        this.transform.eulerAngles=new Vector3(0.0f,0.0f, Random.value * 360.0f);
        this.transform.localScale= Vector3.one * this.size;
        rb.mass=this.size;
    }


   


    private void Update(){
        transform.Rotate(0.1f,0.1f,0.1f);
        if(GameObject.FindGameObjectWithTag("Spaceship") != null)
        {

        lifeTime+=Time.deltaTime;
        if((GameObject.FindGameObjectWithTag("Spaceship").transform.position - this.gameObject.transform.position).magnitude <250f){
               lifeTime=0;
            }
       if(lifeTime>=maxLifeTime){
        Destroy(this.gameObject);
       }
        }
     


    }


   


    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="bullet")
        {
            VFXbulletCollided.transform.position = other.transform.position;
           Destroy(other.gameObject);
           asteroidHP-=damageReceieved;
            Explode();
        }
        if(asteroidHP<=0){
            AsteroidExplosion.transform.position = this.gameObject.transform.position;
            RockExplode();
            Destroy(this.gameObject);
       }
       if(asteroidHP<=0){
        if(this.name=="PF_Asteorid_Base_1(Clone)" || this.name=="PF_Asteorid_Base_2(Clone)" || this.name=="PF_Asteorid_Base_3(Clone)"){
            coin coins=Instantiate(coinprefab,this.transform.position,this.transform.rotation);
            //coins.coinDecay();
        }
        else if(this.name=="PF_Asteorid_Gold_1(Clone)" || this.name=="PF_Asteorid_Gold_2(Clone)" || this.name=="PF_Asteorid_Gold_3(Clone)"){
            coin coins=Instantiate(coinprefab,this.transform.position,this.transform.rotation);
            //coins.coinDecay();
        }
        else if(this.name=="PF_Asteorid_Iron_1(Clone)" || this.name=="PF_Asteorid_Iron_2(Clone)" || this.name=="PF_Asteorid_Iron_3(Clone)" || this.name=="PF_Asteorid_Iron_4(Clone)"){
            coin coins=Instantiate(coinprefab,this.transform.position,this.transform.rotation);
            //coins.coinDecay();
        }
        else if(this.name=="PF_Asteroid_Large_1(Clone)" || this.name=="PF_Asteroid_Large_2(Clone)" || this.name=="PF_Asteroid_Large_3(Clone)"){
            coin coins=Instantiate(coinprefab,this.transform.position,this.transform.rotation);
            //coins.coinDecay();
        } 
       }
    }

    void Explode()
    {
        VFXbulletCollided.SetActive(false);
        VFXbulletCollided.SetActive(true);
    }

    void RockExplode()
    {
        AsteroidExplosion.SetActive(false);
        AsteroidExplosion.SetActive(true);
    }
   


    public void SetTrajectory(Vector3 direction){
        direction.y=0f;
        rb.AddForce(direction *speed*Random.Range(-0.5f, 0.5f),ForceMode.Acceleration);
    }

}
