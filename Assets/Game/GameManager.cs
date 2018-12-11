using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording = true;
    private float fixDelatTime;
    private bool isPaused;

    private void Start()
    {
        PlayerPrefsManager.UnlockLevel(2);
      //  print(PlayerPrefsManager.IsLevelUnlocked(1));
       // print(PlayerPrefsManager.IsLevelUnlocked(2));
       // fixDelatTime = Time.fixedDeltaTime;
    }



    // Update is called once per frame
    void Update () {
		
        if(CrossPlatformInputManager.GetButton("Fire1"))
        {
            recording = false;
          
        }
        else
            {
            recording = true;
         
            }

        if(CrossPlatformInputManager.GetButton("Pause") )
        {
            isPaused = true;
            PauseGame();
        }else
        {
            isPaused = false;
            ResumeGame();
        }
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
       // Time.fixedDeltaTime = fixDelatTime;

    }

    private void PauseGame()
    {
        Time.timeScale = 0;
       // Time.fixedDeltaTime = 0;
      
    }

    private void OnApplicationPause(bool pause)
    {
        isPaused = pause;
    }
}
