using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    // Start is called before the first frame update
    public float CoinDecaytimer=10f;
    private void Update() {
        transform.Rotate(0.1f,0.1f,0.1f);
    }


      
    public void coinDecay(){
        Destroy(this.gameObject,CoinDecaytimer);
    }

}
