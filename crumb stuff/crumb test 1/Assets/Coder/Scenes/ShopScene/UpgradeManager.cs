using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private GameObject minimap;
    public spaceshipController spaceship;
    public Weapon weapon;

    void Awake()
    {
        minimap = GameObject.Find("Minimap");
    }
    void Start()
    {
        minimap.SetActive(false);
    }

    public void ActivateMinimap()
    {
        minimap.SetActive(true);
    }

    public void ShipUpgrade()
    {
        float upgradeAmounth = 1.5f;
        spaceship.turnspeed *= 1.1f;
        spaceship.movespeed *= upgradeAmounth;
        spaceship.maxspeed  *= upgradeAmounth;
    }

    public void UpgradeGun()
    {
        weapon.cooldown = 0;
    }
}
