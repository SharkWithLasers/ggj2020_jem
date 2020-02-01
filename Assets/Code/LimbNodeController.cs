using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbNodeController : MonoBehaviour
{
  public class Entry {
    public LimbNode node;
    public bool attached;
    public LimbNodeType preferredAttachment;
  }

  private List<Entry> nodes = new List<Entry>();

  public void AddBodyPart(LimbNode node)
  {
    
  }

  public void AddHand()
  {}

  public void AddLimb() {}

  public void AddTorso() {}

  public void AddFoot() {}

  private bool CanAttachToLimb(Entry currentLimb, Entry limbToCheck)
  {
    return !currentLimb.attached;
  }
}
