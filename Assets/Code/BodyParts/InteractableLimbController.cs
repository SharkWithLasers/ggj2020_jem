using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLimbController : MonoBehaviour
{
  private void OnTriggerStay2D(Collider2D other)
  {
    CheckForInput(other);
  }

  private void CheckForInput(Collider2D other)
  {
    if (Input.GetKey(KeyCode.E) && other.name == "PlayerInteraction")
    {
      LimbNodeController nodeController = gameObject.GetComponent<LimbNodeController>();
      other.GetComponentInChildren<BodyPartController>().AddBodyPart(nodeController);
    }
  }
}
