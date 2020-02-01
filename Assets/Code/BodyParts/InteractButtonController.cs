using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButtonController : MonoBehaviour
{
  SpriteRenderer sprite;

  private void Start()
  {
    sprite = gameObject.GetComponent<SpriteRenderer>();
  }

  public void Show()
  {
    sprite.enabled = true;
  }

  public void Hide()
  {
    sprite.enabled = false;
  }
}
