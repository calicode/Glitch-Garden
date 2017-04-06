using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    static int starPower;
    const int STARPOWERDEFAULT = 20;
    public static float fortLife;
    static private AttackerSpawner[] spawnersArray;
    // Use this for initialization
    void Start()
    {
        starPower = STARPOWERDEFAULT;
        UpdateSpawnersArray();
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
    public static int GetNumSpawners()
    {
        return spawnersArray.Length;
    }
    static void UpdateSpawnersArray()
    {
        spawnersArray = GameObject.FindObjectsOfType<AttackerSpawner>();

    }

    public static void DeactiveLaneSpawner(float ypos)
    {

        int kittens = GameObject.FindGameObjectsWithTag("pumpkitten").Length - 1;

        if (kittens <= 0)
        {
            GameOver();
        }
        foreach (AttackerSpawner laneSpawner in spawnersArray)
        {

            if (laneSpawner)
            {
                if (laneSpawner.transform.position.y == ypos)
                {
                    Destroy(laneSpawner);

                }
            }
        }
        UpdateSpawnersArray();
    }


    static void GameOver()
    {
        LevelManager.LoadLevel("Game Over");
    }
}


