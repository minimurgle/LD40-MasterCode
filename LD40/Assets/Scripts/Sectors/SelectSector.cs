using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSector : MonoBehaviour {

    public GameObject selectedSector;
    public GameObject infoPanel;
    public Pause pause;

    void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            CastRayToClick();
        }
	}

    public void CastRayToClick()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Sector" && infoPanel.activeInHierarchy != true && pause.pauseMenuUp != true)
        {
            selectedSector = hit.collider.gameObject;
            infoPanel.GetComponent<SectorInfoPanel>().OpenInfoPanel();
        }
    }
}
