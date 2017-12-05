using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventUI : MonoBehaviour {

    public BaseCrimeEvents baseCrimeEvents;
    public BaseGoodEvents baseGoodEvents;

    public GameObject eventPanel;
    public Text eventText;
    public Text event2Text;
    public Text event3Text;
    public bool event1Taken;
    public bool event2Taken;
    public bool eventPanelUp = false;





	public void UpdateCrimeEventUI()
    {
        event1Taken = true;
        eventPanel.SetActive(true);
        eventPanelUp = true;
        eventText.text = baseCrimeEvents.baseCrimeEventsList[baseCrimeEvents.choosenEvent] + " in " + baseCrimeEvents.turnManager.sectors[baseCrimeEvents.choosenSector];
    }

    public void UpdateGoodEventUI()
    {
        event1Taken = true;
        eventPanel.SetActive(true);
        eventPanelUp = true;
        eventText.text = baseGoodEvents.baseGoodEventsList[baseGoodEvents.choosenEvent] + " in " + baseGoodEvents.turnManager.sectors[baseGoodEvents.choosenSector];
    }

    public void GameOverEvent()
    {
        
        eventPanel.SetActive(true);
        eventPanelUp = true;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            CloseEventPanel();
        }
    }

    public void CloseEventPanel()
    {
        event1Taken = false;
        event2Taken = false;
        eventPanel.SetActive(false);
        eventPanelUp = false;
    }
}
