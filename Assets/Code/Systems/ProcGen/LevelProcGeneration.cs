using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenInputs
{
    public Vector2 sizeInUnits;

    public int numLimbs;

    public int numFeet;

    public int numHands;

    public int numTorsos;

    public int numHeads;
}

[CreateAssetMenu(menuName = "ScriptableObjects/Systems/LevelProcGen")]
public class LevelProcGeneration : ScriptableObject
{
    [SerializeField] private GameObject[] tombstonePrefabs;

    [SerializeField] private GameObject backgroundPrefab;


    private List<Grave> currentGraves = new List<Grave>();

    // RE
    public List<Grave> GenerateLevel(LevelGenInputs lgi)
    {
        ClearPreviousShit();

        // generate map
        GenerateBackground(lgi.sizeInUnits);

        GenerateObjectsByHaltonSequence(lgi);

        //graveobjects modified in halton sequence function
        return currentGraves;
    }

    public List<Grave> GetGraves()
    {
      return currentGraves;
    }

    void GenerateBackground(Vector2 sizeInUnits)
    {
        var bgGO = Instantiate(backgroundPrefab);
        bgGO.transform.localScale = new Vector3(sizeInUnits.x, sizeInUnits.y, 1);
        bgGO.GetComponent<BackgroundTextureScale>().Setup(sizeInUnits);
    }

    void GenerateObjectsByHaltonSequence(
        LevelGenInputs levelGenInputs)
    {
        //drop the first 0-20 values
        var goNumber = (int)(UnityEngine.Random.value * 20);

        var lowPrimes = new List<int> { 2, 3, 5 }.OrderBy(x => UnityEngine.Random.value).ToList();
        var xPrime = lowPrimes[0];
        var yPrime = lowPrimes[1];

        void AddGraveWithLoot(LimbNodeType lootType, int numLoot)
        {
            for (var i = 0; i < numLoot; i++)
            {
                var location = new Vector3(
                GetHaltonSequenceNumber(goNumber, xPrime) * levelGenInputs.sizeInUnits.x - levelGenInputs.sizeInUnits.x / 2,
                GetHaltonSequenceNumber(goNumber, yPrime) * levelGenInputs.sizeInUnits.y - levelGenInputs.sizeInUnits.y / 2,
                0f);

                var prefabIndex = Mathf.Min(
                    (int)(UnityEngine.Random.value * tombstonePrefabs.Length),
                    tombstonePrefabs.Length - 1);

                var tombstoneGO = Instantiate(tombstonePrefabs[prefabIndex], location, Quaternion.identity);
                var tombStoneComponent = tombstoneGO.GetComponent<Grave>();

                currentGraves.Add(tombStoneComponent);
                tombStoneComponent.SetLoot(lootType);
                goNumber++;
            }
        }

        AddGraveWithLoot(LimbNodeType.LIMB, levelGenInputs.numLimbs);
        AddGraveWithLoot(LimbNodeType.HAND, levelGenInputs.numHands);
        AddGraveWithLoot(LimbNodeType.TORSO, levelGenInputs.numTorsos);
        AddGraveWithLoot(LimbNodeType.FOOT, levelGenInputs.numFeet);
        AddGraveWithLoot(LimbNodeType.HEAD, levelGenInputs.numHeads);

    }

    private void ClearPreviousShit()
    {
        if (currentGraves != null)
        {
            foreach (var go in currentGraves)
            {
                if (go != null)
                {
                    Destroy(go.gameObject);
                }
            }
        }

        currentGraves = new List<Grave>();
    }

    private static float GetHaltonSequenceNumber(int index, int basePrime)
    {
        var f = 1f;
        var r = 0f;

        while (index > 0)
        {
            f /= basePrime;
            r += f * (index % basePrime);
            index /= basePrime;
        }

        return r;
    }

}