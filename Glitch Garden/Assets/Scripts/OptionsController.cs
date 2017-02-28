using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider difficultySlider;
    public LevelManager levelManager;

    private Jukebox jukebox;
    private AudioSource audioSource;
    // Use this for initialization
    void Start()
    {
        jukebox = GameObject.FindObjectOfType<Jukebox>();
        volumeSlider.value = PlayerPrefs_Manager.GetMasterVolume();
        difficultySlider.value = PlayerPrefs_Manager.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        jukebox.SetVolume(volumeSlider.value);
    }
    public void SaveAndExit()
    {

        PlayerPrefs_Manager.SetMasterVolume(volumeSlider.value);
        PlayerPrefs_Manager.SetDifficulty(difficultySlider.value);
        LevelManager.LoadLevel("Main Menu");
    }

    public void SetDefaults()
    {
        volumeSlider.value = 0.5f;
        difficultySlider.value = 2;
    }
}
