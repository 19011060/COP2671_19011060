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
    private int score;
    public bool isGameActive;
    public GameObject pauseMenu;
    private bool isGamePaused;
    public UnityEvent OnGamePause;
    public UnityEvent OnGameResume;


    // Start is called before the first frame update
    void Start()
    {
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
        score = 0;
        ResumeGame();
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }

    public void LevelComplete()
    {
        isGameActive = false;
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
