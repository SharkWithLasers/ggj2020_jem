using ScriptableObjectArchitecture;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private FloatVariable timeLeftInSeconds;

    [SerializeField] private FloatVariable levelDuration;

    [SerializeField] private GameEvent TimeForLevelFinishedEvent;
    private bool countingDown;

    public void Start()
    {
        InitTimer();
    }

    public void InitTimer()
    {
        countingDown = false;
        timeLeftInSeconds.Value = levelDuration.Value;
    }

    // Update is called once per frame
    void Update()
    {
        if (!countingDown)
        {
            return;
        }

        timeLeftInSeconds.Value = Mathf.Max(0f, timeLeftInSeconds.Value - Time.deltaTime);

        if (timeLeftInSeconds <= 0f || Mathf.Approximately(timeLeftInSeconds, 0f))
        {
            TimeForLevelFinishedEvent.Raise();
            countingDown = false;
        }
    }

    public void OnLevelStarted()
    {
        countingDown = true;
    }

    public void OnLevelVictory()
    {
        countingDown = false;
    }
}