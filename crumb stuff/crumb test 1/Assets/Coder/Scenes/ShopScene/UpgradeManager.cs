using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;

    private GameObject minimap;
    private GameObject Radar;
    public spaceshipController spaceship;
    public Weapon weapon;
    //public upgradeTrigger upgradetrigger;
    public Animator[] anim;

    private GameObject[] mainEngine;
    private GameObject[] upgradedEngine;


    private const string CooldownUpgradeKey = "CooldownUpgrade";
    private const string ShipUpgradeKey = "ShipUpgradeKey";
    private int UpgradeCost = 1000;
    
    void Awake()
    {
       if(WinningZone.collectedAllComponent)
            anim[0].SetBool("Alert", true);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        minimap = GameObject.Find("Minimap");
        Radar = GameObject.FindGameObjectWithTag("Radar");
        mainEngine = GameObject.FindGameObjectsWithTag("MainEngine");
        upgradedEngine = GameObject.FindGameObjectsWithTag("UpgradedEngine");
        for(int i = 0; i < upgradedEngine.Length; i++)
            upgradedEngine[i].SetActive(false);
    }
    public void Start()
    {
        if (PlayerPrefs.HasKey("engineUpgrade"))
        {
            for(int i = 0; i < mainEngine.Length; i++)
                mainEngine[i].SetActive(false);
            for(int i = 0; i < upgradedEngine.Length; i++)
                upgradedEngine[i].SetActive(true);
        }
                
        if (PlayerPrefs.HasKey("minimapUpgraded")) 
        {
            minimap.SetActive(true); 
            Radar.SetActive(true);
        }
        else
        {
            minimap.SetActive(false);
            Radar.SetActive(false);
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
        if (MoneyManager.money >= UpgradeCost)
        {
            if (minimap != null && Radar != null)
            {
                minimap.SetActive(true);
                Radar.SetActive(true);
            }
            MoneyManager.money -= UpgradeCost;
            if (MoneyManager.instance.currentMoney != null)
            {
                MoneyManager.instance.currentMoney.text = MoneyManager.money.ToString();
            }
            PlayerPrefs.SetInt("minimapUpgraded", 1);
            SceneManager.LoadScene("Zone");
        }
    }

    public void AllComponentCollected()
    {
        WinningZone.collectedAllComponent = true;
        PlayerPrefs.SetInt("hyperDrive", 1);
        SceneManager.LoadScene("Zone");
    }

    public void ShipUpgrade()
    {
        if (MoneyManager.money >= UpgradeCost)
        {
            float upgradeAmounth = 1.8f;
            spaceship.turnspeed *= 1.2f;
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
            PlayerPrefs.SetInt("engineUpgrade", 1);
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
            PlayerPrefs.SetInt("gunUpgraded", 1);
        SceneManager.LoadScene("Zone");
        }
    }




    public void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
}
