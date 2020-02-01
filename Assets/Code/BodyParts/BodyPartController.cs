﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartController : MonoBehaviour
{
  class Entry
  {
    public LimbNodeController limbNodeController;
    public LimbNodeType limbNodeType;
  }

  private List<Entry> bodyParts = new List<Entry>();

  // Initialize the first node we can use to connect
  private void Start() {
    Entry entry = new Entry();
    entry.limbNodeController = gameObject.GetComponentInChildren<LimbNodeController>();
    entry.limbNodeType = entry.limbNodeController.limbType;

    bodyParts.Add(entry);
  }

  public void AddBodyPart(LimbNodeController bodyPart)
  {
    LimbNode newBodyPartNode = bodyPart.ResolveNode();
    // Check if there are any unattached nodes that can be used
    if (newBodyPartNode == null) return;

    Entry currentBodyPartEntry = bodyParts.Find(part => {
      LimbNode partNode = part.limbNodeController.ResolveNode();

      return partNode != null;
    });

    // See if there is a node we can use to attach to
    if (currentBodyPartEntry == null) return;

    bodyPart.transform.parent = gameObject.transform;

    Entry entry = new Entry();
    entry.limbNodeController = bodyPart;
    entry.limbNodeType = bodyPart.limbType;

    bodyParts.Add(entry);

    bodyPart.AttachNode(newBodyPartNode.nodeType);
    currentBodyPartEntry.limbNodeController.AttachNode(
      currentBodyPartEntry.limbNodeController.ResolveNode().nodeType
    );

    Destroy(bodyPart.GetComponent<InteractableLimbController>());
    Destroy(bodyPart.GetComponent<CircleCollider2D>());
  }
}
