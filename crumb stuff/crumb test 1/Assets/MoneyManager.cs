using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    public TextMeshProUGUI currentMoney;

    static public int money = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //currentMoney = FindObjectOfType<TextMeshProUGUI>();
    }
    public void moneyCounting()
    {
        
    }
    void update()
    {
        currentMoney.text = money.ToString();
    }


}
