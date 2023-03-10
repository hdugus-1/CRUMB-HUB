using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followBullet : MonoBehaviour
{
    public GameObject VFXbulletCollided2;
    public GameObject RockExplosion;

    private void Awake()
    {
        VFXbulletCollided2.SetActive(false); RockExplosion.SetActive(false);
        asteroid.VFXbulletCollided = VFXbulletCollided2;
        asteroid.AsteroidExplosion = RockExplosion;
    }

}
