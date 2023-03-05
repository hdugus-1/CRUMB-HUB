using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUpgrade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
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



}
