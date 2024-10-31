using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
    public enum TimerType
    {
        CountDown, CountUp
    }

    public UnityEvent OnTimerStart;
    public UnityEvent<float> OnTimerUpdate;
    public UnityEvent OnTimerStop;

    public TimerType timeType = TimerType.CountDown;
    public float startTime = 5;
    private float elapsedTime = 0;
    private Coroutine timerCoroutine = null;

    private void Start()
    {
        StartTimer();
    }
    public void StartTimer()
    {
        OnTimerStart.Invoke();
        timerCoroutine = StartCoroutine(StartTimerCo());
    }

    public void UpdateTimer(float timeValue)
    {
        OnTimerUpdate.Invoke(timeValue);
    }

    public void StopTimer()
    {
        if (timerCoroutine != null)
        {
            OnTimerStop.Invoke();
            StopCoroutine(timerCoroutine);
            Debug.Log("Timer's Done.");
        }
       
        
    }

    private IEnumerator StartTimerCo()
    {
        if (timeType == TimerType.CountDown)
        {
            elapsedTime = startTime;
        }
        yield return null;

        while (elapsedTime >= 0)
        {
            elapsedTime -= Time.deltaTime;
            UpdateTimer(elapsedTime);

            if(elapsedTime <= 0)
            {
                StopTimer();
            }
            yield return null;
        }


    }
}
