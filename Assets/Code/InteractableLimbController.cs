using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLimbController : MonoBehaviour
{
  private void OnTriggerStay2D(Collider2D other)
  {
    if (Input.GetKeyDown(KeyCode.E))
    {
      other.GetComponent<BodyPartController>().AddBodyPart(
        gameObject.GetComponent<LimbNodeController>()
      );
    }
  }
}
