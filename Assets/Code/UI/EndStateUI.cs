using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndStateUI : MonoBehaviour
{
    [SerializeField] private string victoryText = "You win!";
    [SerializeField] private string timesUpText = "Times up!";


    [SerializeField] private TextMeshProUGUI endStateText;
    [SerializeField] private TextMeshProUGUI replayInstructions;




    // Start is called before the first frame update
    void Start()
    {
        endStateText.gameObject.SetActive(false);
        replayInstructions.gameObject.SetActive(false);
    }

    public void OnVictory()
    {
        endStateText.text = victoryText;

        endStateText.gameObject.SetActive(true);
        replayInstructions.gameObject.SetActive(true);
    }

    public void OnDefeat()
    {
        endStateText.text = timesUpText;

        endStateText.gameObject.SetActive(true);
        replayInstructions.gameObject.SetActive(true);
    }
}
