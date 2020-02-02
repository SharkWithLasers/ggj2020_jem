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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GenLevel();
        }
    }
}
