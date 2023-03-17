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
    public void ShopCollectAllComponent()
    {
        if(HyperDriveManager.HyperDriveCounter >= 1) 
        {
            UpgradeManager.instance.AllComponentCollected();
        }
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
        PlayerPrefs.SetInt("engineUpgrade", 1);
        UpgradeManager.instance.ShipUpgrade();
    }


}
