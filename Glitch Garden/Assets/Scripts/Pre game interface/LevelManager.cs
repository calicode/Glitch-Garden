using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    static string lastPlayedLevel;

    public static string[] playableLevels = { "Level_01", "Level_02", "Level_03", "Level_04" };
    void Start()
    {


        SceneManager.sceneLoaded += this.OnLoadCallback;
    }



    void OnLoadCallback(Scene scene, LoadSceneMode sceneMode)
    {
        string levelname = scene.name;
        if (playableLevels.Contains(levelname))
        {


            lastPlayedLevel = levelname;

        }


    }
    public static void LoadLevel(string name)
    {
        Debug.Log("Loading level " + name);

        SceneManager.LoadSceneAsync(name);
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
        SceneManager.LoadSceneAsync(levelIndex);
    }

    public static void ReloadCurrent()
    {
        LoadLevel(lastPlayedLevel);
    }
}

