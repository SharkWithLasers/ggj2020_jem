using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbNodeController : MonoBehaviour
{
  public LimbNodeType bodyPartType;
  public List<LimbNode> nodes;

  private void Start() {
    for (int i = 0; i < nodes.Count; i++)
    {
      nodes[i].nodeType = bodyPartType;
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

  public void AttachNode(LimbNodeType nodeType)
  {
    LimbNode node = ResolveNodeByType(nodeType);
    node.Attach(nodeType);
  }
}
