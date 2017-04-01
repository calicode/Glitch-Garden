using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static int starPower = 15;
    public static float fortLife;
    static private AttackerSpawner[] spawnersArray;
    // Use this for initialization
    void Start()
    {
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
        print("Update spawn called length is" + spawnersArray.Length);
        print("array to string" + spawnersArray.ToString());

    }

    public static void DeactiveLaneSpawner(float ypos)
    {

        int kittens = GameObject.FindGameObjectsWithTag("pumpkitten").Length - 1;

        if (kittens <= 0)
        {
            LevelManager.LoadLevel("Game Over");
        }
        foreach (AttackerSpawner laneSpawner in spawnersArray)
        {

            if (laneSpawner)
            {
                if (laneSpawner.transform.position.y == ypos)
                {
                    Debug.Log("trying to disable spawner at" + ypos);
                    Destroy(laneSpawner); // this might break the next line

                    Debug.Log("Disabled spawner in ypos" + ypos);
                }
            }
        }
        UpdateSpawnersArray();
    }


}


