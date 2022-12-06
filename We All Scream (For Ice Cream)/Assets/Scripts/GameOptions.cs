using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOptions : MonoBehaviour
{

    public LevelManager LevelManager;
    public GameObject pausePanel;
    public GameObject unpauseButton;
    public bool IsPaused = false;


    private void Start()
    {
        pausePanel.SetActive(false);
    }

    void Update()
    {

        if (Input.GetKey("escape") && IsPaused == false)
        {
           LevelManager.Pause();
           pausePanel.SetActive(true);
           IsPaused = true;
           Debug.Log("Pausing Game");
        }


    }

    public void UnPauseButton()
    {
                LevelManager.UnPause();
                IsPaused = false;
                pausePanel.SetActive(false);
                Debug.Log("UnPausing Game");
    }
}
