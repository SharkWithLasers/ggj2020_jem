using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLimbController : MonoBehaviour
{
  InteractButtonController button;

  private void Start() {
    button = gameObject.GetComponentInChildren<InteractButtonController>();
  }

  private void OnTriggerStay2D(Collider2D other)
  {
    CheckForInput(other);
  }

  private void OnTriggerExit2D(Collider2D other) {
    if (other.name == "PlayerInteraction")
    {
      button.Hide();
    }
  }

  private void CheckForInput(Collider2D other)
  {
    if (other.name == "PlayerInteraction")
    {
      button.Show();
    }

    if (Input.GetKey(KeyCode.E) && other.name == "PlayerInteraction")
    {
      LimbNodeController nodeController = gameObject.GetComponent<LimbNodeController>();
      other.GetComponentInChildren<BodyPartController>().AddBodyPart(nodeController);
    }
  }
}
