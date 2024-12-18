using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerText : MonoBehaviour
{
    private TMPro.TMP_Text m_Text;

    private void Awake()
    {
        m_Text = GetComponent<TMPro.TMP_Text>();
    }

    public void UpdateText(float value)
    {  
        m_Text.text = $"{value:F2}";
    }
}
