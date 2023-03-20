using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class shopTextManager : MonoBehaviour
{
    public TextMeshProUGUI UpgradeShip;
    public TextMeshProUGUI UpgradeGun;
    public TextMeshProUGUI UpgradeRadar;
    public TextMeshProUGUI HyperdriveComponent;
    public GameObject[] image;


    private string cost = ":- 1000";
    private string soldOut = ":- SOLD OUT";

    private void Start()
    {
        UpgradeShip.text = cost;
        UpgradeGun.text = cost;
        UpgradeRadar.text = cost;

        if (PlayerPrefs.HasKey("engineUpgrade"))
            UpgradeShip.text = soldOut;
        if (PlayerPrefs.HasKey("gunUpgraded"))
            UpgradeGun.text = soldOut;
        if (PlayerPrefs.HasKey("minimapUpgraded"))
            UpgradeRadar.text = soldOut;
        if (PlayerPrefs.HasKey("hyperDrive"))
        {
            HyperdriveComponent.text = "Collected!";
            foreach(GameObject go in image)
            {
                go.SetActive(false);
            }
        }
    }
}
