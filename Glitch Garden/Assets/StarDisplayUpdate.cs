using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StarDisplayUpdate : MonoBehaviour
{
    static Text starDisplay;
    void Start()
    {
        starDisplay = GetComponent<Text>();

    }

    // Update is called once per frame

    void Update()
    {
    }

    public static void UpdateStarCount()
    {

        starDisplay.text = ResourceManager.GetStarCount().ToString();

    }
}
