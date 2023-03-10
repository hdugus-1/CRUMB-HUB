using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUpgrade : MonoBehaviour
{
    public TextMeshProUGUI currentMoney;
    public TextMeshProUGUI currentComponents;
 
   
    
    void Start()
    {
        
        currentMoney.text = MoneyManager.money.ToString();
        currentComponents.text = HyperDriveManager.HyperDriveCounter.ToString();
    }

    public void ShopActivateMinimap()
    {
        UpgradeManager.instance.ActivateMinimap();
        PlayerPrefs.SetInt("minimapUpgraded", 1);
    }

    public void ShopUpgradeGun()
    {
        UpgradeManager.instance.UpgradeGun();
    }

    public void ShopUpgradeShip()
    {
        UpgradeManager.instance.ShipUpgrade();
    }

    /*public void UpgradeHyperDrive()
    {
        UpgradeManager.instance.HyperDriveUpgrade();
    }*/

}
