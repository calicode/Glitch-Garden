using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public Slider volumeSlider;
    public LevelManager levelManager;

    private Jukebox jukebox;
    private AudioSource audioSource;
    // Use this for initialization
    void Start()
    {
        jukebox = GameObject.FindObjectOfType<Jukebox>();
        volumeSlider.value = PlayerPrefs_Manager.GetMasterVolume();
    }

    // Update is called once per frame
    void Update()
    {
        jukebox.SetVolume(volumeSlider.value);
    }
    public void SaveAndExit()
    {

        PlayerPrefs_Manager.SetMasterVolume(volumeSlider.value);
        LevelManager.LoadLevel("Main Menu");
    }


}
