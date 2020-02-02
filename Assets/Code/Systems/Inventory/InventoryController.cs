using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private InventoryUIGrayout[] handGrayouts;

    [SerializeField] private InventoryUIGrayout[] limbGrayouts;

    [SerializeField] private InventoryUIGrayout[] feetGrayouts;

    [SerializeField] private InventoryUIGrayout torsoGrayout;

    [SerializeField] private InventoryUIGrayout headGrayout;

    [SerializeField] private PlayerInventory playerInventory;




  public void Add(LimbNodeType type)
  {
        /*
    if (type == LimbNodeType.HAND) {
      Instantiate(handPrefab, transform);
    }
    else if (type == LimbNodeType.LIMB) {
      Instantiate(limbPrefab, transform);
    }
    else if (type == LimbNodeType.FOOT) {
      Instantiate(footPrefab, transform);
    }*/
  }

    public void OnInventoryChanged()
    {
        if (playerInventory.bodyPartToCount.ContainsKey(LimbNodeType.HAND))
        {
            var numHands = Mathf.Min(
                playerInventory.bodyPartToCount[LimbNodeType.HAND],
                handGrayouts.Length
                );
            for (int i = 0; i < numHands; i++)
            {
                handGrayouts[i].AddAsInventory();
            }
        }

        if (playerInventory.bodyPartToCount.ContainsKey(LimbNodeType.FOOT))
        {
            var numFeet = Mathf.Min(
                playerInventory.bodyPartToCount[LimbNodeType.FOOT],
                feetGrayouts.Length);
            for (int i = 0; i < numFeet; i++)
            {
                feetGrayouts[i].AddAsInventory();
            }
        }

        if (playerInventory.bodyPartToCount.ContainsKey(LimbNodeType.TORSO))
        {
            torsoGrayout.AddAsInventory();
        }

        if (playerInventory.bodyPartToCount.ContainsKey(LimbNodeType.HEAD))
        {
            headGrayout.AddAsInventory();
        }

        if (playerInventory.bodyPartToCount.ContainsKey(LimbNodeType.LIMB))
        {
            var numLimbs = Mathf.Min(
                playerInventory.bodyPartToCount[LimbNodeType.LIMB],
                limbGrayouts.Length);

            for (int i = 0; i < numLimbs*2; i+=2)
            {
                limbGrayouts[i].AddAsInventory();
                limbGrayouts[i+1].AddAsInventory();
            }
        }
    }
}
