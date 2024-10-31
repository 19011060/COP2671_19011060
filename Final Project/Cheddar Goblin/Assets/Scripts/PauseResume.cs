using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResume : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        Time.timeScale = 0;
        Debug.Log("Pause");
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
        Debug.Log("Resume");
    }
}
