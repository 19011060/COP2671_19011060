using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private TMPro.TMP_Text m_Text;

    private void Awake()
    {
        m_Text = GetComponent<TMPro.TMP_Text>();
    }

    public void UpdateText(float value)
    {  
        m_Text.text = $"Cheese X {value:F0}";
    }

    public void LevelScore(float cheeseScore, float timescore, float levelScore)
    {
        m_Text.text = $"Cheese Score:\t{cheeseScore:F0}\nTime Score:\t{timescore:F0}\n\nTotal Score:\t{levelScore:F0}";
    }
}
