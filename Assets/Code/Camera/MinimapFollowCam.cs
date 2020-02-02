using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapFollowCam : MonoBehaviour
{
  public Transform target;

  private void LateUpdate() {
    Vector3 newPosition = target.position;
    newPosition.z = transform.position.z;
    transform.position = newPosition;
  }
}
