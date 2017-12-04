using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCrimeEvents : MonoBehaviour {

    public List<string> baseCrimeEventsList = new List<string>();
    public int choosenEvent;
    public int choosenSector;
    public TurnManager turnManager;
    public EventUI eventUI;

    public void Start()
    {
        baseCrimeEventsList.Add("A few stores were robbed");//0
        baseCrimeEventsList.Add("Drug addictions are skyrocketing");//1
        baseCrimeEventsList.Add("A major power outage has happened");//2
        baseCrimeEventsList.Add("A factory has gone bankrupt and layed off all it's workers");//3
        baseCrimeEventsList.Add("Prisons are full and have to release people to make space");//4
        baseCrimeEventsList.Add("People are rioting in the streets");//5
    }

    public void PickEvent()
    {
        int totalEvents;
        totalEvents = baseCrimeEventsList.Count;
        choosenEvent = Random.Range(0, totalEvents);
        ChooseSector();
        if (choosenEvent == 0)
        {
            Event0();
        }
        else if (choosenEvent == 1)
        {
            Event1();
        }
        else if (choosenEvent == 2)
        {
            Event2();
        }
        else if (choosenEvent == 3)
        {
            Event3();
        }
        else if (choosenEvent == 4)
        {
            Event4();
        }
        else if (choosenEvent == 5)
        {
            Event5();
        }
        eventUI.UpdateCrimeEventUI();
    }

    public void Event0()
    {
        
        turnManager.sectors[choosenSector].GetComponent<SectorInfo>().crimeLevel += Random.Range(15, 30);
    }
    public void Event1()
    {
        turnManager.sectors[choosenSector].GetComponent<SectorInfo>().crimeRate += Random.Range(15, 30);
    }
    public void Event2()
    {
        turnManager.sectors[choosenSector].GetComponent<SectorInfo>().crimeLevel += Random.Range(15, 30);
    }
    public void Event3()
    {
        turnManager.sectors[choosenSector].GetComponent<SectorInfo>().crimeRate += Random.Range(15, 30);
    }
    public void Event4()
    {
        turnManager.sectors[choosenSector].GetComponent<SectorInfo>().crimeRate += Random.Range(15, 30);
    }
    public void Event5()
    {
        turnManager.sectors[choosenSector].GetComponent<SectorInfo>().crimeLevel += Random.Range(15, 30);
    }

    public void ChooseSector()
    {
        int sectorCount;
        sectorCount = turnManager.sectors.Count;
        choosenSector = Random.Range(0, sectorCount);
    }
}
