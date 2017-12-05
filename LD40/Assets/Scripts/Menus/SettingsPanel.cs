using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour {

    public Slider volumeSlider;

    public void Start()
    {
        if (PlayerPrefs.GetInt("returningPlayer") == 1)
        {
            volumeSlider.value = PlayerPrefs.GetFloat("SetVolume");
        }
        else
        {
            PlayerPrefs.SetFloat("SetVolume", .1f);
            volumeSlider.value = PlayerPrefs.GetFloat("SetVolume");
        }
        
    }

	public void ClosePanel()
    {
        PlayerPrefs.SetInt("returningPlayer", 1);
        PlayerPrefs.SetFloat("SetVolume", volumeSlider.value);
        gameObject.SetActive(false);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            ClosePanel();
        }
    }
}
