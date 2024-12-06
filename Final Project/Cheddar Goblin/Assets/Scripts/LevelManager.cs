using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject track1;
    public GameObject track2;
    public GameObject track3;
    public GameObject nextLevel;
    public GameObject endDemo;
    private TimeManager timeManager;
    void Start()
    {
        timeManager = GameObject.Find("Time Manager").GetComponent<TimeManager>();
    }

    public void NextLevel()
    {
        if (track1.activeInHierarchy == true)
        {
            track1.SetActive(false);
            track2.SetActive(true);
            track3.SetActive(false);

            timeManager.StopTimer();        // Stop the current timer
            timeManager.startTime = 35;    // Update the start time
            timeManager.StartTimer();      // Restart the timer   
        }
        else if (track2.activeInHierarchy == true)
        {
            track1.SetActive(false);
            track2.SetActive(false);
            track3.SetActive(true);
            nextLevel.SetActive(false);
            endDemo.SetActive(true);
            timeManager.StopTimer();        // Stop the current timer
            timeManager.startTime = 45;    // Update the start time
            timeManager.StartTimer();      // Restart the timer
        }
    }
}
