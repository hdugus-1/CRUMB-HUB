using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Experimental.GraphView;

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
        if (!PlayerPrefs.HasKey("minimapUpgraded"))
        {
            UpgradeManager.instance.ActivateMinimap();
            PlayerPrefs.SetInt("minimapUpgraded", 1);
        }
    }

    public void ShopUpgradeGun()
    {
        if(!PlayerPrefs.HasKey("gunUpgraded"))
        {
            UpgradeManager.instance.UpgradeGun();
            PlayerPrefs.SetInt("gunUpgraded", 1);
        }
    }

    public void ShopUpgradeShip()
    {
        if(!PlayerPrefs.HasKey("engineUpgrade"))
        {
            PlayerPrefs.SetInt("engineUpgrade", 1);
            UpgradeManager.instance.ShipUpgrade();
        }
    }


}
