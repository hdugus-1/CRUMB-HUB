using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public float CoinDecaytimer=2f;
    private void Update() {
        transform.Rotate(0.1f,0.1f,0.1f);
    }

       private void OnTriggerEnter(Collider other) {
        if(other.tag=="Spaceship"){
            Destroy(this.gameObject);
        }
    }
    public void coinDecay(){
        Destroy(this.gameObject,CoinDecaytimer);
    }
}
