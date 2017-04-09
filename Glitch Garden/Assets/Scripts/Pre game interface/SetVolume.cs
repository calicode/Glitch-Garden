using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVolume : MonoBehaviour

{
    public Jukebox jukeBox;
    // Use this for initialization
    void Start()
    {
        jukeBox = FindObjectOfType<Jukebox>();
        jukeBox.SetVolume(PlayerPrefs_Manager.GetMasterVolume());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
