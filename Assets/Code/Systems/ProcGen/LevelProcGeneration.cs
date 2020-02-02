using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenInputs
{
    public Vector2 sizeInUnits;

    public int numberOfGraves;

    public float ratioLimbs;

    public float ratioFeet;

    public float ratioHands;

    public float ratioTorsos;
}

[CreateAssetMenu(menuName = "ScriptableObjects/Systems/LevelProcGen")]
public class LevelProcGeneration : ScriptableObject
{
    [SerializeField] private GameObject[] tombstonePrefabs;

    [SerializeField] private GameObject backgroundPrefab;

    private List<GameObject> curGameObjects;

    private List<GameObject> backgroundGameObjects;

    public void GenerateLevel(LevelGenInputs lgi)
    {
        ClearPreviousShit();

        // generate map
        GenerateBackground(lgi.sizeInUnits);

        GenerateObjectsByHaltonSequence(lgi);
    }

    void GenerateBackground(Vector2 sizeInUnits)
    {
        var bgGO = Instantiate(backgroundPrefab);
        bgGO.transform.localScale = new Vector3(sizeInUnits.x, sizeInUnits.y, 1);
        bgGO.GetComponent<BackgroundTextureScale>().Setup(sizeInUnits);
    }

    /*
    void GenerateBackground(Vector2 sizeInUnits)
    {
        var xMin = -(sizeInUnits.x / 2);
        var xMax = sizeInUnits.y / 2;

        var yMin = -(sizeInUnits.y / 2);
        var yMax = sizeInUnits.y / 2;

        for (var curX = xMin; curX <= xMax; curX += 2)
        {
            for (var curY = yMin; curY <= yMax; curY += 2)
            {
                var bgGO = Instantiate(backgroundPrefab, new Vector2(curX, curY), Quaternion.identity);

                backgroundGameObjects.Add(bgGO);
            }
        }
    }*/

    void GenerateObjectsByHaltonSequence(
        LevelGenInputs levelGenInputs)
    {
        //drop the first 0-20 values
        var goNumber = (int)(UnityEngine.Random.value * 20);

        var lowPrimes = new List<int> { 2, 3, 5 }.OrderBy(x => UnityEngine.Random.value).ToList();
        var xPrime = lowPrimes[0];
        var yPrime = lowPrimes[1];

        var curMax = levelGenInputs.ratioLimbs;
        var maxIntLimbs = levelGenInputs.numberOfGraves * curMax;

        curMax += levelGenInputs.ratioFeet;
        var maxIntFeet = levelGenInputs.numberOfGraves * curMax;

        curMax += levelGenInputs.ratioHands;
        var maxIntHands = levelGenInputs.numberOfGraves * curMax;

        curMax += levelGenInputs.ratioTorsos;
        var maxIntTorsos = levelGenInputs.numberOfGraves * curMax;

        for (int i = 0; i < levelGenInputs.numberOfGraves; i++)
        {
            var location = new Vector3(
                GetHaltonSequenceNumber(goNumber, xPrime) * levelGenInputs.sizeInUnits.x - levelGenInputs.sizeInUnits.x / 2,
                GetHaltonSequenceNumber(goNumber, yPrime) * levelGenInputs.sizeInUnits.y - levelGenInputs.sizeInUnits.y / 2,
                0f);

            var prefabIndex = Mathf.Min(
                (int)(UnityEngine.Random.value * tombstonePrefabs.Length),
                tombstonePrefabs.Length - 1);

            var tombstoneGO = Instantiate(tombstonePrefabs[prefabIndex], location, Quaternion.identity);
            curGameObjects.Add(tombstoneGO);

            var lootType = i > maxIntTorsos
                ? LimbNodeType.HEAD
                : i > maxIntHands
                    ? LimbNodeType.TORSO
                    : i > maxIntFeet
                       ? LimbNodeType.HAND
                       : i > maxIntLimbs
                           ? LimbNodeType.FOOT
                           : LimbNodeType.LIMB;

            tombstoneGO.GetComponent<Grave>().SetLoot(lootType);

            goNumber++;
        }
    }

    private void ClearPreviousShit()
    {
        foreach (var go in curGameObjects)
        {
            Destroy(go.gameObject);
        }

        curGameObjects = new List<GameObject>();
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