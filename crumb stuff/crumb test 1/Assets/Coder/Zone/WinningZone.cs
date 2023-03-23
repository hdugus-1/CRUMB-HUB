using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinningZone : MonoBehaviour
{
    static public bool collectedAllComponent = false;
    public Rigidbody spaceshipRigidbody;
    public CinemachineVirtualCamera cam;
    public Animator[] anim;

    float time = 0f;
    float lerpDuration = 1f;
   
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Spaceship"))
        {
            if (collectedAllComponent == false)
            {
                collectedAllComponent= false;
                StartCoroutine(FovIncrease());//increases fov and loads win screen
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

    IEnumerator FovIncrease()
    {
        if (cam != null)
        {
            while(time < lerpDuration)
            {
                cam.m_Lens.FieldOfView = Mathf.Lerp(cam.m_Lens.FieldOfView, 170f, time);
                time += Time.deltaTime;
                if (time > lerpDuration-0.2f) SceneManager.LoadScene("UI_win");
                yield return null;
            }
        }
        SceneManager.LoadScene("UI_win");
    }


}
