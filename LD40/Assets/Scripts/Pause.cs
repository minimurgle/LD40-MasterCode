using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {


    public OverlayHandler handler;
    public GameObject pausePanel;
    public bool pauseMenuUp = false;
    public bool overlayEnabled = false;

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) && pauseMenuUp == false)
        {
            PauseGame();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && pauseMenuUp == true)
        {
            UnPauseGame();
        }
	}

    public void EnableOverlay()
    {

        if (overlayEnabled == false)
        {
            foreach (GameObject sectorOverlay in handler.overlayPanels)
            {
                sectorOverlay.GetComponent<SectorOverlay>().EnableOverlay();
            }
            overlayEnabled = true;
        }
        else if (overlayEnabled == true)
        {
            foreach (GameObject sectorOverlay in handler.overlayPanels)
            {
                sectorOverlay.GetComponent<SectorOverlay>().DisableOverlay();
            }
            overlayEnabled = false;
        }
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        pauseMenuUp = true;
    }

    public void UnPauseGame()
    {
        pausePanel.gameObject.SetActive(false);
        pauseMenuUp = false;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void DisplayHelp()
    {
        //todo
    }

}
