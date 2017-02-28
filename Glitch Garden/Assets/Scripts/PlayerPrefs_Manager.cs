using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerPrefs_Manager : MonoBehaviour
{

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_UNLOCK_KEY = "level_unlocked_";


    public static void SetMasterVolume(float volume)
    {
        if (volume > 0f && volume < 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else { Debug.LogError("Master volume out of range"); }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel(int level)
    {

        if (level < SceneManager.sceneCountInBuildSettings - 1)
        {
            PlayerPrefs.SetInt(LEVEL_UNLOCK_KEY + SceneManager.GetActiveScene().buildIndex, 1);
        }
        else { Debug.LogError("Level " + level + " not in build order"); }
    }

    public static bool IsLevelUnlocked(int level)
    {
        int unlocked = PlayerPrefs.GetInt(LEVEL_UNLOCK_KEY + level);
        if (unlocked == 1) { return true; }
        else
        {
            Debug.LogError("Level " + level + " not unlocked");
            return false;
        }
    }
    public static void SetDifficulty(float difficulty)
    {
        if (difficulty > 0 && difficulty <= 3)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else { Debug.LogError("tried to set too high a difficulty"); }

    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}
