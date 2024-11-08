using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public bool isGameActive;
    public GameObject pauseMenu;
    private TimeManager timeManager;
    private ScoreManager scoreManager;
    private bool isGamePaused;
    public UnityEvent OnGamePause;
    public UnityEvent OnGameResume;


    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        timeManager = GameObject.Find("Time Manager").GetComponent<TimeManager>();
        isGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(!isGamePaused)
            {
                
            }
            else
            {
                
            }
        }
    }

    public void StartGame()
    {
        scoreManager.score = 0;
        ResumeGame();
    }

    

    public void LevelComplete()
    {
        isGameActive = false;
        timeManager.StopTimer();
    }
    
    public void GameOver()
    {
        isGameActive = false;
    }

    public void RestartGame()
    {

    }

    private void PauseGame()
    {
        isGamePaused = true;
        //pauseMenu.SetActive(true);
    }

    private void ResumeGame()
    {
        isGamePaused = false;
        //pauseMenu.SetActive(false);
    }
}
