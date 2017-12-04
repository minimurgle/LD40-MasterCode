using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerAndAproval : MonoBehaviour {

    [Header("Power")]
    public int policePower = 10;
    public Text policePowerText;

    [Space(2)]

    [Header("Aproval")]
    public int publicAproval = 80;
    public Text publicAprovalText;
    public int aprovalMiscMod;

    [Space(2)]

    public TurnManager turnManager;
    public PlayerMoney playermoney;
    int totalCrime;
    int averageCrime;
    int totalPresence;
    int averagePresence;


    public void Start()
    {
        UpdatePowerAndAproval();
    }

    public void UpdatePowerAndAproval() {
        UpdatePower();
        UpdateAproval();
	}

    void UpdatePower()
    {
        policePower = 10;
        totalPresence = 0;
        foreach (GameObject sector in turnManager.sectors)
        {
            totalPresence += sector.GetComponent<SectorInfo>().policePresence;
        }
        if (turnManager.sectors.Count != 0)
        {
            averagePresence = totalPresence / turnManager.sectors.Count / 2;
        }
        else
        {
            averagePresence = totalPresence / 5;
        }
        policePower += averagePresence;

        policePowerText.text = "Police Power:" + policePower.ToString();
    }

    void UpdateAproval()
    {
        totalCrime = 0;
        publicAproval = 80;
        foreach (GameObject sector in turnManager.sectors)
        {
            totalCrime += sector.GetComponent<SectorInfo>().crimeLevel;
        }
        if (turnManager.sectors.Count != 0)
        {
            averageCrime = totalCrime / turnManager.sectors.Count;
        }
        else
        {
            averageCrime = totalCrime / 5;
        }
        publicAproval -= averageCrime / 2;
        publicAproval += aprovalMiscMod;
        if (policePower >= 25)
        {
            int policeOverPower;
            policeOverPower = policePower - 20;
            publicAproval -= policeOverPower;
        }
        if (publicAproval < 0)
        {
            publicAproval = 0;
        }
        publicAprovalText.text = "Public Approval:" + publicAproval.ToString();
    }

}
