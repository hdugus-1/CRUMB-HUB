using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinningZone : MonoBehaviour
{
    static public bool collectedAllComponent;
    public Rigidbody spaceshipRigidbody;

    private void Awake()
    {
        collectedAllComponent = false;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Spaceship") && collectedAllComponent)
        {
            SceneManager.LoadScene("UI_win");
        }
        else
        {
            Vector3 force = -spaceshipRigidbody.velocity.normalized * 100f;
            spaceshipRigidbody.velocity = Vector3.zero;
            spaceshipRigidbody.AddForce(force, ForceMode.Impulse);
        }
    }


}
