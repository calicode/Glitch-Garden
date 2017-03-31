using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static int starPower = 5;
    public static float fortLife;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame

    public static void AddStar()
    {
        starPower += 1;
        StarDisplayUpdate.UpdateStarCount();
    }
    public static int GetStarCount()
    {
        return starPower;
    }


    public static bool UseStars(int amount)
    {
        if (GetStarCount() >= amount)
        {
            starPower -= amount;
            StarDisplayUpdate.UpdateStarCount();
            return true;
        }
        else { Debug.LogWarning("Tried to use more stars than I have"); return false; }
    }
}
