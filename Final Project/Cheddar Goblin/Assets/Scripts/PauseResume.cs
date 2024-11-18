using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResume : MonoBehaviour
{
    public GameObject UI;
    // Pauses the game and disables the GameObject
    public void Pause()
    {
        Time.timeScale = 0; // Pauses the game
        Debug.Log("Pause");
        gameObject.SetActive(true); // Enables the GameObject
        UI.SetActive(false);
    }

    // Resumes the game and enables the GameObject
    public void Resume()
    {
        Time.timeScale = 1; // Resumes the game
        Debug.Log("Resume");
        gameObject.SetActive(false); // Enables the GameObject
        UI.SetActive(true);
    }
}