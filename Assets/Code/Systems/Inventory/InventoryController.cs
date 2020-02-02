using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryController : MonoBehaviour
{


  public GameObject handPrefab;
  public GameObject limbPrefab;
  public GameObject footPrefab;

  public void Add(LimbNodeType type)
  {
    if (type == LimbNodeType.HAND) {
      Instantiate(handPrefab, transform);
    }
    else if (type == LimbNodeType.LIMB) {
      Instantiate(limbPrefab, transform);
    }
    else if (type == LimbNodeType.FOOT) {
      Instantiate(footPrefab, transform);
    }
  }

    public void OnInventoryChanged()
    {

    }
}
