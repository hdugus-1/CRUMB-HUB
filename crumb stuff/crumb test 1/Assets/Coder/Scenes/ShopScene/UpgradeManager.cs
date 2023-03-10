using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;

    private GameObject minimap;
    public GameObject Radar;
    public spaceshipController spaceship;
    public Weapon weapon;
    //public upgradeTrigger upgradetrigger;


    private const string CooldownUpgradeKey = "CooldownUpgrade";
    private const string ShipUpgradeKey = "ShipUpgradeKey";
    private int UpgradeCost = 1000;
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

        MoneyManager moneyManager = FindObjectOfType<MoneyManager>();
        if (moneyManager != null)
        {
            moneyManager.currentMoney.text = MoneyManager.money.ToString();

        }
    }

    public void ActivateMinimap()
    {
        if(MoneyManager.money >= UpgradeCost)
        {
            if (minimap != null)
            {
                minimap.SetActive(true);
            }
            MoneyManager.money -= UpgradeCost;
            if (MoneyManager.instance.currentMoney != null)
            {
                MoneyManager.instance.currentMoney.text = MoneyManager.money.ToString();
            }
            SceneManager.LoadScene("Zone");
        }
    }

    public void ShipUpgrade()
    {
        if (MoneyManager.money >= UpgradeCost)
        {
            float upgradeAmounth = 2.5f;
            spaceship.turnspeed *= 1.1f;
            spaceship.movespeed *= upgradeAmounth;
            spaceship.maxspeed  *= upgradeAmounth;

            PlayerPrefs.SetFloat("TurnSpeed", spaceship.turnspeed);
            PlayerPrefs.SetFloat("MoveSpeed", spaceship.movespeed);
            PlayerPrefs.SetFloat("MaxSpeed", spaceship.maxspeed);
            MoneyManager.money -= UpgradeCost;
            if (MoneyManager.instance.currentMoney != null)
            {
                MoneyManager.instance.currentMoney.text = MoneyManager.money.ToString();
            }
            SceneManager.LoadScene("Zone");
        }
    }

    public void UpgradeGun()
    {
        if (MoneyManager.money >= UpgradeCost)
        {
            float upgradeAmount = 0.5f;
            weapon.cooldown *= upgradeAmount;
            PlayerPrefs.SetFloat(CooldownUpgradeKey, upgradeAmount);
            MoneyManager.money -= UpgradeCost;
            if (MoneyManager.instance.currentMoney != null)
            {
                MoneyManager.instance.currentMoney.text = MoneyManager.money.ToString();
            }
            SceneManager.LoadScene("Zone");
        }
    }

    /*public void HyperDrive()
    {
        if (upgradetrigger.HyperDriveCounter == 4)
        {
            //add Hyperdrive/SetActive
        }
        
    }*/



    public void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
}
