using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouthScript : MonoBehaviour
{

    public targetController target;
    public int goldprice = 150;
    // Start is called before the first frame update
    void Start()
    {
         MoneyManager moneyManager = FindObjectOfType<MoneyManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("grabgold") && target.grabstatus == true)
        {
            spaceshipController.staticStarShineEffect.SetActive(false);
            spaceshipController.staticStarShineEffect.SetActive(true);
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
