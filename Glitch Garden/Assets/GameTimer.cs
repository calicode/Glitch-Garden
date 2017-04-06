using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameTimer : MonoBehaviour
{
    /* manage level time 
    progress slider as time tics up 
    show win screen when slider gets to end

     */

    Slider slider;
    int currentTime;
    public int endTime = 36000;
    bool levelBeat = false;
    // Use this for initialization
    void Start()
    {
        currentTime = 0;
        slider = GetComponent<Slider>();
        slider.maxValue = endTime;
        slider.value = 0;
    }

    // Update is called once per frame

    // could also use TimeSinceLevel Loaded here. 
    void Update()
    {
        currentTime++;
        if (currentTime >= endTime && !levelBeat)
        {
            // once i start displaying win/lose as an overlay this will need to be changed so it doesn't fire after a lose
            levelBeat = true;
            ShowWinScreen();
        }
        else
        {
            slider.value = currentTime;
        }

    }

    void ShowWinScreen()
    {
        LevelManager.LoadLevel("Win");
    }
}
