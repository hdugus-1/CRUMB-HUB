using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouthScript : MonoBehaviour
{

    public targetController target;
    public int goldprice = 500;
    // Start is called before the first frame update
    void Start()
    {
         MoneyManager moneyManager = FindObjectOfType<MoneyManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("gold") && target.grabstatus == true)
        {
            target.grabstatus = false;
            Destroy(other.gameObject);
            MoneyManager.money += goldprice;
            MoneyManager.instance.currentMoney.text = MoneyManager.money.ToString();
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
