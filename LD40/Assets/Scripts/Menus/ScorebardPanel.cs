using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class ScorebardPanel : MonoBehaviour {

    public Text scoreboardText;

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ClosePanel();
        }

        //scoreboardText.text = Analytics.CustomEvent("gameOver").ToString(); Doesnt work
    }
}
