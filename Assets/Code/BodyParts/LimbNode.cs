using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbNode : MonoBehaviour
{
  public LimbNodeType nodeType;
  public LimbNodeType attachedTo = LimbNodeType.NONE;
  private Vector2 offsetFromCenter;

  private void Start() {
    float xOffset = transform.localPosition.x;
    float yOffset = transform.localPosition.y;

    offsetFromCenter = new Vector2(xOffset, yOffset);
  }

  public void Attach(LimbNodeType nodeType)
  {
    attachedTo = nodeType;
  }
}
