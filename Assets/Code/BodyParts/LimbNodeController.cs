using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbNodeController : MonoBehaviour
{
  public LimbNodeType limbType;
  public List<LimbNode> nodes;

  private void Start() {
    for (int i = 0; i < nodes.Count; i++)
    {
      nodes[i].nodeType = limbType;
    }
  }

  public LimbNode ResolveNode()
  {
    for (int i = 0; i < nodes.Count; i++)
    {
      if (nodes[i].attachedTo == LimbNodeType.NONE) {
        return nodes[i];
      }
    }

    return null;
  }

  public LimbNode ResolveNodeByType(LimbNodeType nodeType)
  {
    for (int i = 0; i < nodes.Count; i++)
    {
      bool isCorrectTypeOfNode = (
        nodes[i].attachedTo == LimbNodeType.NONE &&
        nodes[i].nodeType == nodeType
      );

      if (isCorrectTypeOfNode) {
        return nodes[i];
      }
    }

    return null;
  }

  public Vector3 AttachNode(LimbNodeType nodeType)
  {
    LimbNode node = ResolveNodeByType(nodeType);
    node.Attach(nodeType);
    return node.gameObject.transform.localPosition;
  }

  public void SetPosition(Vector3 nodeLocation, LimbNodeController attachPoint)
  {
    Vector3 attachPointLocation = attachPoint.gameObject.transform.position;

    float xOffset = nodeLocation.x;
    float yOffset = nodeLocation.y;
    
    transform.position = new Vector2(
      xOffset > 0 ? attachPointLocation.x + xOffset : attachPointLocation.x - xOffset,
      yOffset > 0 ? attachPointLocation.y + yOffset : attachPointLocation.y - yOffset
    );

    transform.rotation = attachPoint.gameObject.transform.parent.rotation;
  }
}
