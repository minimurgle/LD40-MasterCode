using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayHandler : MonoBehaviour {

    public List<GameObject> overlayPanels;

    public void UpdateOverlays()
    {
        foreach (GameObject overlay in overlayPanels)
        {
            overlay.GetComponent<SectorOverlay>().UpdateOverlay();
        }
    }
}
