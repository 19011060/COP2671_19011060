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
    public bool isLevelComplete;
    public GameObject winMenu;
    public GameObject loseMenu;
    public GameObject ui;
    private TimeManager timeManager;
    private SoundManager soundManager;
    private ScoreManager scoreManager;
    public ScoreText scoreText;
    private bool isGamePaused;
    private AudioSource audioSource;
    public UnityEvent OnGamePause;
    public UnityEvent OnGameResume;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("Goblin").GetComponent<AudioSource>();
        scoreText = scoreText.GetComponent<ScoreText>();
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        timeManager = GameObject.Find("Time Manager").GetComponent<TimeManager>();
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        isGameActive = true;
        isLevelComplete = false;
        timeManager.StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive){
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (!isGamePaused)
                {
                    OnGamePause.Invoke();
                    isGamePaused = true;
                }
                else
                {
                    OnGameResume.Invoke();
                    isGamePaused = false;
                }
            }
        }
        
    }

    public void StartGame()
    {
        isGameActive = true;
        isLevelComplete = false;
        ui.SetActive(true);
        scoreManager.score = 0;
    }

    public void LevelComplete()
    {
        isGameActive = false;
        isLevelComplete = true;
        timeManager.StopTimer();
        float levelScore = scoreManager.score *100 + (timeManager.elapsedTime * 10);
        winMenu.SetActive(true);
        scoreText.LevelScore(scoreManager.score * 100, timeManager.elapsedTime * 10, levelScore);
        ui.SetActive(false);
    }
    
    public void GameOver()
    {
        isGameActive = false;
        timeManager.StopTimer();
        audioSource.PlayOneShot(soundManager.death);
        loseMenu.SetActive(true);
        ui.SetActive(false);
    }
}
