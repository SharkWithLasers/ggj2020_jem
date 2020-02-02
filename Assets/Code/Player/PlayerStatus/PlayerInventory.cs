using System;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Player/Inventory")]
public class PlayerInventory : ScriptableObject
{
    public Dictionary<LimbNodeType, int> requiredBodyParts = new Dictionary<LimbNodeType, int>
    {
        { LimbNodeType.FOOT, 2 },
        { LimbNodeType.HAND, 2 },
        { LimbNodeType.HEAD, 1 },
        { LimbNodeType.LIMB, 4 },
        { LimbNodeType.TORSO, 1 },
    };

    public Dictionary<LimbNodeType, int> bodyPartToCount = new Dictionary<LimbNodeType, int>();

    public GameEvent inventoryAddedGameEvent;

    public GameEvent youWinGameEvent;


    public void AddToInv(LimbNodeType limb)
    {
        if (bodyPartToCount.ContainsKey(limb))
        {
            bodyPartToCount[limb] = bodyPartToCount[limb] + 1;
        }
        else
        {
            bodyPartToCount.Add(limb, 1);
        }

        inventoryAddedGameEvent.Raise();

        var isWinningInv = IsWinningInv();

        if (isWinningInv)
        {
            youWinGameEvent.Raise();
        }
    }

    private bool IsWinningInv()
    {
        foreach (var kvp in requiredBodyParts)
        {
            var headReqType = kvp.Key;
            var headReqCount = kvp.Value;

            if (!bodyPartToCount.ContainsKey(headReqType) ||
                bodyPartToCount[headReqType] < headReqCount)
            {
                return false;
            }
        }

        return true;
    }
}
