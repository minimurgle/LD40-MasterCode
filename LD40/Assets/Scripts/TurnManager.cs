using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour {

    [Header("Refrences")]
    public GameObject sectorInfoPanel;
    public SectorInfoPanel infoPanel;
    public Text warningText;
    public Text turnCounter;
    public SelectSector selectSector;
    public EventHandler eventHandler;
    public PowerAndAproval powAndAprov;
    public PlayerMoney playerMoney;
    public Pause pause;
    public GameOver gameOver;
    public EventUI eventUI;
    public OverlayHandler sectorOverlayHandler;

    [Space(2)]

    public int currentTurn;
    public List<GameObject> sectors;
    int totalCrime;
    int totalCrimeRate;



    





	public void EndTurn()
    {
        if (sectorInfoPanel.activeInHierarchy == false && gameOver.gameLost != true && pause.pauseMenuUp == false && eventUI.eventPanelUp != true)
        {
            totalCrime = 10;
            totalCrimeRate = 10;
            currentTurn += 1;
            foreach (GameObject sector in sectors)
            {
                sector.GetComponent<SectorInfo>().UpdateSector();
            }
            infoPanel.SetInfo();
            powAndAprov.UpdatePowerAndAproval();
            playerMoney.UpdateMoney();

            
            if (Random.Range(0, 100) <= 30)
            {
                eventHandler.ChooseBaseEvent();
            }
            turnCounter.text = "Turn: " + currentTurn.ToString();
            foreach (GameObject sector in sectors)
            {
                totalCrimeRate += sector.GetComponent<SectorInfo>().crimeRate;
                totalCrime += sector.GetComponent<SectorInfo>().crimeLevel;
            }
            if (totalCrime == 0 && totalCrimeRate == 0)
            {
                gameOver.GameWon();
            }
            sectorOverlayHandler.UpdateOverlays();

        }
        
    }


}
