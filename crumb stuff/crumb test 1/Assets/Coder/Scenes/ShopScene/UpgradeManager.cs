using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;

    private GameObject minimap;
    public spaceshipController spaceship;
    public Weapon weapon;


    private const string CooldownUpgradeKey = "CooldownUpgrade";
    private const string ShipUpgradeKey = "ShipUpgradeKey";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        minimap = GameObject.Find("Minimap");
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("minimapUpgraded")) 
        {
            minimap.SetActive(true); 
        }
        else
        {
            minimap.SetActive(false); 
        }
        float cooldownUpgrade = PlayerPrefs.GetFloat(CooldownUpgradeKey, 1f);
        weapon.cooldown *= cooldownUpgrade;
        spaceship.turnspeed = PlayerPrefs.GetFloat("TurnSpeed", spaceship.turnspeed);
        spaceship.movespeed = PlayerPrefs.GetFloat("MoveSpeed", spaceship.movespeed);
        spaceship.maxspeed = PlayerPrefs.GetFloat("MaxSpeed", spaceship.maxspeed);
    }

    public void ActivateMinimap()
    {
        if (minimap != null)
        {
            minimap.SetActive(true);
        }
        //Debug.Log("Minimap!!");
    }

    public void ShipUpgrade()
    {
        float upgradeAmounth = 2.5f;
        spaceship.turnspeed *= 1.1f;
        spaceship.movespeed *= upgradeAmounth;
        spaceship.maxspeed  *= upgradeAmounth;

        PlayerPrefs.SetFloat("TurnSpeed", spaceship.turnspeed);
        PlayerPrefs.SetFloat("MoveSpeed", spaceship.movespeed);
        PlayerPrefs.SetFloat("MaxSpeed", spaceship.maxspeed);
    }

    public void UpgradeGun()
    {
        float upgradeAmount = 0.1f;
        weapon.cooldown *= upgradeAmount;
        PlayerPrefs.SetFloat(CooldownUpgradeKey, upgradeAmount);
    }





    public void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
}
