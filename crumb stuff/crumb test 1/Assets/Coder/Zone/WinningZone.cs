using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinningZone : MonoBehaviour
{
    static public bool collectedAllComponent = false;
    public Rigidbody spaceshipRigidbody;
    public Animator[] anim;

    private void Awake()
    {
        //collectedAllComponent = false;
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Spaceship"))
        {
            if (collectedAllComponent)
            {
                collectedAllComponent= false;
                SceneManager.LoadScene("UI_win");
            }
            else
            {
                anim[0].SetBool("Alert", true);
                Vector3 force = -spaceshipRigidbody.velocity.normalized * 10f;
                spaceshipRigidbody.velocity = Vector3.zero;
                spaceshipRigidbody.AddForce(force, ForceMode.Impulse);
            }
        }
        
    }


}
