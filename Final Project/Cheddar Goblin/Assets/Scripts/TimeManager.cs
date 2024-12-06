using System.Collections;
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
    private GameManager gameManager;
    public TimerType timeType = TimerType.CountDown;
    public float startTime;
    public float elapsedTime = 0;
    public float endTime = 0;
    private Coroutine timerCoroutine = null;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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
            Debug.Log("Time's up.");
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
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Title Screen [Start Here]")
                {
                    StopTimer();
                }
                else
                {
                    gameManager.GameOver();
                }
            }
            yield return null;
        }


    }
}
