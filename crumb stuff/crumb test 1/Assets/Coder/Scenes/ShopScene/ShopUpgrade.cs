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
        if(HyperDriveManager.HyperDriveCounter >= 4) 
        {
            UpgradeManager.instance.AllComponentCollected();
        }
    }
    public void ShopActivateMinimap()
    {
        if (!PlayerPrefs.HasKey("minimapUpgraded"))
        {
            UpgradeManager.instance.ActivateMinimap();
            //PlayerPrefs.SetInt("minimapUpgraded", 1);
        }
    }

    public void ShopUpgradeGun()
    {
        if(!PlayerPrefs.HasKey("gunUpgraded"))
        {
            UpgradeManager.instance.UpgradeGun();
        }
    }

    public void ShopUpgradeShip()
    {
        if(!PlayerPrefs.HasKey("engineUpgrade"))
        {
            UpgradeManager.instance.ShipUpgrade();
        }
    }


}
