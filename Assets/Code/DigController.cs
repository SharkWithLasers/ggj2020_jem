using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigController : MonoBehaviour
{
  private float digSpeed = 1f;
  void Update()
  {
    // TODO: Add controller support
    if (Input.GetKeyDown(KeyCode.E)) {
      Dig();
    }
  }

  public void Dig()
  {
    // How does digging work? Perhaps a grave has a trigger, and a player inside that trigger
    // holding the interact button 'digs'
  }
}
