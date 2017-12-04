using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour {

    public Slider volumeSlider;

    public void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("SetVolume");
    }

	public void ClosePanel()
    {
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
