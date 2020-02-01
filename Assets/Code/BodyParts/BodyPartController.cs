using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartController : MonoBehaviour
{
  class Entry
  {
    public LimbNodeController bodyPartController;
    public LimbNodeType bodyPartType;
  }

  private List<Entry> bodyParts = new List<Entry>();

  public void AddBodyPart(LimbNodeController bodyPart)
  {
    LimbNode newBodyPartNode = bodyPart.ResolveNode();
    // Check if there are any unattached nodes that can be used
    if (newBodyPartNode == null) {
      return;
    }

    Entry currentBodyPartEntry = bodyParts.Find(part => {
      LimbNode partNode = part.bodyPartController.ResolveNodeByType(newBodyPartNode.nodeType);

      return partNode != null;
    });

    bodyPart.transform.parent = gameObject.transform;

    Entry entry = new Entry();
    entry.bodyPartController = bodyPart;
    entry.bodyPartType = bodyPart.bodyPartType;

    bodyParts.Add(entry);

    bodyPart.AttachNode(newBodyPartNode.nodeType);
    currentBodyPartEntry.bodyPartController.AttachNode(
      currentBodyPartEntry.bodyPartController.ResolveNodeByType(newBodyPartNode.nodeType).nodeType
    );
  }
}
