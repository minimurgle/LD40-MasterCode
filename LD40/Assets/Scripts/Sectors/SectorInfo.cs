using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorInfo : MonoBehaviour
{
    public int crimeLevel;
    public int crimeRate;
    public int incomePerTurn;
    public bool sectorLost;
    public int policePresence = 10;
    public int incomeThisTurn;
    public GameObject overlay;

    public int selectedAction;
    //0 = none
    //1 = cut a deal
    //2 = fight crime

    GameObject manager;

    public void Start()
    {
        manager = GameObject.Find("Manager");
        manager.GetComponent<TurnManager>().sectors.Add(gameObject);

        crimeLevel = Random.Range(0, 20);
        crimeRate = Random.Range(5, 20);
        incomePerTurn = Random.Range(50, 200);
        incomeThisTurn = incomePerTurn - crimeLevel;
    }

    public void DoAction()
    {
      if (selectedAction == 0)
        {
            if (Random.Range(0, 100) <= 40)
            {
                crimeRate += Random.Range(1, 5);
            }
        }
      else if (selectedAction == 1)
        {
            crimeLevel += Random.Range(10, 25);
            manager.GetComponent<PlayerMoney>().totalMoney += Random.Range(100, 300 - incomeThisTurn);
        }
      else if (selectedAction == 2)
        {
            crimeLevel -= Random.Range(5,10 + policePresence);
            manager.GetComponent<PlayerMoney>().totalMoney -= Random.Range(100, 400);
            if (Random.Range(0, 100) <= 40)
            {
                crimeRate -= Random.Range(1, 5 + policePresence / 2);
            }
        }
      else if (selectedAction == 3)
        {
            crimeLevel -= Random.Range(10, 30);
            manager.GetComponent<PlayerMoney>().totalMoney -= Random.Range(200, 500);
            policePresence += Random.Range(5, 15);
        }
    }

    public void UpdateSector()
    {
        crimeLevel += crimeRate;
        incomeThisTurn = incomePerTurn - crimeLevel;
        manager.GetComponent<PlayerMoney>().totalMoney += incomeThisTurn;
        if (crimeLevel >= 100)
        {
            sectorLost = true;
        }
        DoAction();
        ResetValues();  
    }

    void ResetValues()
    {
        selectedAction = 0;
        if (crimeRate <= 0)
        {
            crimeRate = 0;
        }
        if (crimeLevel <= 0)
        {
            crimeLevel = 0;
        }
        if (incomeThisTurn <= 0)
        {
            incomeThisTurn = 0;
        }
    }
}
