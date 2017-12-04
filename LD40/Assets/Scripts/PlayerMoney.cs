using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class PlayerMoney : MonoBehaviour {

    public int totalMoney = 1000;
    public Text moneyText;

    public void Start()
    {
        UpdateMoney();
    }

    public void UpdateMoney()
    {
        moneyText.text = "$" + totalMoney.ToString();
        if (totalMoney < 0)
        {
            totalMoney = 0;
        }
  
    }

    

    
	
}
