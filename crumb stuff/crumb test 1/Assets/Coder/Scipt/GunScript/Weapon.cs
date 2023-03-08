using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private bool canShoot = true;
    public float cooldown = 0.5f;
    public Transform GetFirePoint()
    {
        return firePoint;
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if(canShoot && context.performed)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            canShoot= false;
            StartCoroutine(Cooldown());
        }
    }
    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        canShoot= true;
    }
}
