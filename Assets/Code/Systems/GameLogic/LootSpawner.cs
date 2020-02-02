﻿using System;
using System.Collections;
using System.Collections.Generic;
using KammBase;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/GameLogic/LootSpawner")]
public class LootSpawner : ScriptableObject
{
    [SerializeField] private GameObject handLootPrefab;
    [SerializeField] private GameObject limbLootPrefab;
    [SerializeField] private GameObject footLootPrefab;
    [SerializeField] private GameObject torsoLootPrefab;

    public void OnGraveLooted(GraveAndLoot graveAndLoot)
    {
        var grave = graveAndLoot.grave;
        var loot = graveAndLoot.loot;


        var prefabToUse = GetPrefabToUse(loot);

        if (prefabToUse.HasValue)
        {
            var prefabPosition = grave.transform.position + new Vector3(0.25f, 0.25f);
            Instantiate(prefabToUse.Value, prefabPosition, Quaternion.identity);
        }
    }

    private Option<GameObject> GetPrefabToUse(LimbNodeType loot)
    {
        if (loot == LimbNodeType.HAND)
        {
            return handLootPrefab;
        }

        if (loot == LimbNodeType.LIMB)
        {
            return limbLootPrefab;
        }

        if (loot == LimbNodeType.FOOT)
        {
            return footLootPrefab;
        }

        if (loot == LimbNodeType.TORSO)
        {
            return torsoLootPrefab;
        }

        return Option<GameObject>.None;

    }
}