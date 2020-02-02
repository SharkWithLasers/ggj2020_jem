using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelProcGeneration levelProcGen;
    private bool levelFinished;

    //[SerializeField]

    public void Start()
    {
        GenLevel();
    }

    // Start is called before the first frame update
    void GenLevel()
    {
        levelFinished = false;
        
        var sizeInUnits = new Vector2(101, 101);

        var levelGenInput = new LevelGenInputs
        {
            sizeInUnits = sizeInUnits,
            numLimbs = 10,
            numHands = 6,
            numFeet = 6,
            numTorsos = 6,
            numHeads = 1,
        };

        levelProcGen.GenerateLevel(levelGenInput);

        // fuck it
        GetComponent<LevelTimer>().OnLevelStarted();
    }

    private void Update()
    {

        if (levelFinished && Input.GetButtonDown("Player_YButton"))
        {
            SceneManager.LoadScene(1);
        }

        if (levelFinished && Input.GetButtonDown("Player_StartButton"))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void OnLevelFinished()
    {
        levelFinished = true;
    }
}
