using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;

public class TimerDurationUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerDuration;
    [SerializeField] private FloatVariable timeLeftInLevel;

    // Start is called before the first frame update
    void Start()
    {
        timerDuration.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timerDuration.enabled = true;
        timerDuration.text = timeLeftInLevel.Value.ToString("00");
    }
}
