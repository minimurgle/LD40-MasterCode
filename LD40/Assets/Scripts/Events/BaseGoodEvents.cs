using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGoodEvents : MonoBehaviour {

    public List<string> baseGoodEventsList = new List<string>();
    public int choosenEvent;
    public int choosenSector;
    public TurnManager turnManager;
    public EventUI eventUI;

    public void Start()
    {
        baseGoodEventsList.Add("A charity event happened");//0
        baseGoodEventsList.Add("Rehab has been made readily available");//1
        baseGoodEventsList.Add("Some people have volenteered to help the police");//2
        baseGoodEventsList.Add("A new factory has been build opening up more jobs in");//3
        baseGoodEventsList.Add("A few criminals have turned themselves in to the police");//4
        baseGoodEventsList.Add("Some dealers were ratted out by their rivals");//5
    }

    public void PickEvent()
    {
        int totalEvents;
        totalEvents = baseGoodEventsList.Count;
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
        eventUI.UpdateGoodEventUI();
    }

    public void Event0()
    {

        turnManager.sectors[choosenSector].GetComponent<SectorInfo>().crimeRate -= Random.Range(15, 30);
    }
    public void Event1()
    {
        turnManager.sectors[choosenSector].GetComponent<SectorInfo>().crimeRate -= Random.Range(15, 30);
    }
    public void Event2()
    {
        turnManager.sectors[choosenSector].GetComponent<SectorInfo>().policePresence += Random.Range(5, 10);
    }
    public void Event3()
    {
        turnManager.sectors[choosenSector].GetComponent<SectorInfo>().crimeRate -= Random.Range(15, 30);
    }
    public void Event4()
    {
        turnManager.sectors[choosenSector].GetComponent<SectorInfo>().crimeLevel -= Random.Range(15, 30);
    }
    public void Event5()
    {
        turnManager.sectors[choosenSector].GetComponent<SectorInfo>().crimeLevel -= Random.Range(15, 30);
    }

    public void ChooseSector()
    {
        int sectorCount;
        sectorCount = turnManager.sectors.Count;
        choosenSector = Random.Range(0, sectorCount);
    }
}
