using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelProcGeneration levelProcGen;

    //[SerializeField] private 

    // Start is called before the first frame update
    void GenLevel()
    {
        var sizeInUnits = new Vector2(101, 101);

        var numGraves = 20;
        var ratioLimbs = 0.8f;
        var ratioHands = 0.05f;
        var ratioFeet = 0.05f;
        var ratioTorsos = 0.05f;

        var levelGenInput = new LevelGenInputs
        {
            sizeInUnits = sizeInUnits,
            numberOfGraves = numGraves,
            ratioLimbs = ratioLimbs,
            ratioHands = ratioHands,
            ratioFeet = ratioFeet,
            ratioTorsos = ratioTorsos,
        };

        levelProcGen.GenerateLevel(levelGenInput);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GenLevel();
        }
    }
}
