using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbNode : MonoBehaviour
{
  public LimbNodeType nodeType;
  public LimbNodeType attachedTo = LimbNodeType.NONE;

  public void Attach(LimbNodeType nodeType)
  {
    attachedTo = nodeType;
  }
}
