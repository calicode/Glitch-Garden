using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    static string lastPlayedLevel;

    public static string[] playableLevels = { "Level_01", "Level_02", "Level_03", "Level_04" };

    public static void LoadLevel(string name)
    {
        if (playableLevels.Contains(name))
        {

            lastPlayedLevel = name;

        }

        Debug.Log("Loading level " + name);

        SceneManager.LoadScene(name);
    }

    public void LoadLevelWrapper(string name)
    {
        LoadLevel(name);


    }

    public void LoadCurrentWrapper()
    {
        ReloadCurrent();
    }
    public void LoadNextWrapper() { LoadNextLevel(); }
    public void QuitGame()
    {
        Debug.Log("quit called");

        Application.Quit();

    }

    /// <summary>
    /// Loads the next level.
    /// </summary>
    public static void LoadNextLevel()
    {
        int levelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        print("Levelindex is " + levelIndex);
        Scene levelName = SceneManager.GetSceneAt(levelIndex);
        print("levelname is" + levelName.name);
        //LoadLevel(levelName);
    }

    public static void ReloadCurrent()
    {
        LoadLevel(lastPlayedLevel);
    }
}

