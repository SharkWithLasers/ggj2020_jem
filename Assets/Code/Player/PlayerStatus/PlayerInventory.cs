using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Player/Inventory")]
public class PlayerInventory : ScriptableObject
{
    public Dictionary<LimbNodeType, int> bodyPartToCount = new Dictionary<LimbNodeType, int>();

    public GameEvent inventoryAddedGameEvent;

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
    }
}
