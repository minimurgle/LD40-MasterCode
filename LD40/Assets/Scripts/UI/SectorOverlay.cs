using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SectorOverlay : MonoBehaviour {

    public OverlayHandler handler;
    public TurnManager turnManager;
    public Pause pause;
    public SectorInfo sectorInfo;
    public Text crimeRate;
    public Text crimeLevel;
    public Text income;
    public Text policePresence;
   



    public void Start()
    {
        handler.overlayPanels.Add(gameObject);
        gameObject.SetActive(false);
    }


    public void EnableOverlay()
    {
       
        UpdateOverlay();
        gameObject.SetActive(true);
    }


    public void UpdateOverlay()
    {
        crimeRate.text = "CR:" + sectorInfo.crimeRate.ToString();
        crimeLevel.text = "CL:" + sectorInfo.crimeLevel.ToString();
        income.text = "$" + sectorInfo.incomeThisTurn.ToString();
        policePresence.text = "PR:" + sectorInfo.policePresence.ToString();
    }

    public void DisableOverlay()
    {
        gameObject.SetActive(false);
    }
	
}
