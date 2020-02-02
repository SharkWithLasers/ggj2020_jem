using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private PlayerMeta playerMeta;

    public GameObject playerInteraction;

    private void Start()
    {
    }

    private void Update()
    {
        float x = Input.GetAxis($"{playerMeta.InputPrefix}Horizontal") * speed;
        float y = Input.GetAxis($"{playerMeta.InputPrefix}Vertical") * speed;

        float xTranslation = x * Time.deltaTime;
        float yTranslation = y * Time.deltaTime;

        transform.Translate(new Vector3(xTranslation, yTranslation, 0));

        float xDirection = Input.GetAxisRaw($"{playerMeta.InputPrefix}Horizontal");
        float yDirection = Input.GetAxisRaw($"{playerMeta.InputPrefix}Vertical");

        FaceXAxis(xDirection);
        FaceYAxis(yDirection);
    }

    public void IncreaseSpeed(float modifier)
    {
        speed += modifier;
    }

    public void DecreaseSpeed(float modifier)
    {
        speed -= modifier;
    }

    private void FaceXAxis(float xDirection)
    {
      if (xDirection > 0 || xDirection < 0) {
        playerInteraction.transform.localScale = new Vector3(
          xDirection,
          playerInteraction.transform.localScale.y,
          playerInteraction.transform.localScale.z
        );

        playerInteraction.transform.localRotation = Quaternion.Euler(
          playerInteraction.transform.rotation.x,
          playerInteraction.transform.rotation.y,
          xDirection * -90 * playerInteraction.transform.localScale.y
        );
      }
    }

    private void FaceYAxis(float yDirection)
    {
      if (yDirection > 0 || yDirection < 0) {
        playerInteraction.transform.localScale = new Vector3(
          playerInteraction.transform.localScale.x,
          yDirection,
          playerInteraction.transform.localScale.z
        );

        playerInteraction.transform.localRotation = Quaternion.Euler(
          playerInteraction.transform.rotation.x,
          playerInteraction.transform.rotation.y,
          0
        );
      }
    }
}

