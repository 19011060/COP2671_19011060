using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public float score;
    public UnityEvent<float> OnScoreUpdate;

    public void UpdateScore(float scoreToAdd)
    {
        score += scoreToAdd;
        OnScoreUpdate.Invoke(score);
    }
}
