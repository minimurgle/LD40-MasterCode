using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour {

    public AudioSource musicPlayer;
	// Update is called once per frame
	public void Update () {
        musicPlayer.volume = PlayerPrefs.GetFloat("SetVolume");
	}
}
