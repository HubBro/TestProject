using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFF_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";

    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0f && volume <= 1.0f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.Log("Master volume out of range");
        }
    }

    public static float GetMasterVolume()
    {       
       return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);     
    }


    public static void SetDifficulty(float difficulty)
    {

        if (difficulty >= 1f && difficulty <= 3f)
        {
            PlayerPrefs.SetFloat(DIFF_KEY, difficulty);
        }
        else
        {
            Debug.Log("Error ot of range ");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFF_KEY);
    }

    public static void UnlockLevel(int level)
    {
        if( level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
        }
        else
        {
            Debug.Log("No level");
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
        bool isLevelUnlocked = (levelValue == 1);

        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            return isLevelUnlocked;
        }
        else
        {
            Debug.Log("No level");
            return false;
        }



    }
}
