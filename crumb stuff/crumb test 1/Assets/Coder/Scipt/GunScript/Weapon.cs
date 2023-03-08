using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject muzzelFlash;
    private bool canShoot = true;
    public float cooldown = 0.5f;

    private void Awake()
    {
        muzzelFlash.SetActive(false);
    }
    public Transform GetFirePoint()
    {
        return firePoint;
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if(canShoot && context.performed)
        {
            muzzelFlash.SetActive(false);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            canShoot= false;
            StartCoroutine(Cooldown());
            muzzelFlash.SetActive(true);
        }
        
    }
    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        
        canShoot= true;
    }
}
