using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionToMainMenu : MonoBehaviour
{
    LevelManager levelManager;
    // Use this for initialization
    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        Invoke("LoadMainMenu", 3f);
    }

    // Update is called once per frame
    void LoadMainMenu()
    {

        levelManager.LoadLevelWrapper("Main Menu");
    }

}
