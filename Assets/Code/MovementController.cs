using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
  private float speed = 1f;

  private void Update()
  {
    float x = Input.GetAxis("Horizontal") * speed;
    float y = Input.GetAxis("Vertical") * speed;

    float xTranslation = x * Time.deltaTime;
    float yTranslation = y * Time.deltaTime;

    transform.Translate(new Vector3(xTranslation, yTranslation, 0));
  }

  public void IncreaseSpeed(float modifier)
  {
    speed += modifier;
  }

  public void DecreaseSpeed(float modifier)
  {
    speed -= modifier;
  }
}
