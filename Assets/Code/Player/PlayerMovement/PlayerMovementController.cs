using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private float offsetFromBorder = 0.5f;

    [SerializeField]
    private PlayerMeta playerMeta;

    public GameObject playerInteraction;
    public Animator handAnimator;

    private float unitSize = 1f;
    private float worldSizeInUnits = 51;
    private float worldMaxX;
    private float worldMaxY;

    private void Start()
    {
      float halfWorldMap = (unitSize * worldSizeInUnits) / 2f;
      worldMaxX = halfWorldMap - offsetFromBorder;
      worldMaxY = halfWorldMap - offsetFromBorder;
    }

    private void Update()
    {
        float x = Input.GetAxis($"{playerMeta.InputPrefix}Horizontal") * speed;
        float y = Input.GetAxis($"{playerMeta.InputPrefix}Vertical") * speed;

        float xTranslation = x * Time.deltaTime;
        float yTranslation = y * Time.deltaTime;

        if (
          transform.position.x > worldMaxX &&
          xTranslation > 0
        ) {
          xTranslation = 0;
        }

        if (
          transform.position.x < -worldMaxX &&
          xTranslation < 0
        ) {
          xTranslation = 0;
        }

        if (
          transform.position.y > worldMaxY &&
          yTranslation > 0
        ) {
          yTranslation = 0;
        }

        if (
          transform.position.y < -worldMaxY &&
          yTranslation < 0
        ) {
          yTranslation = 0;
        }

        transform.Translate(new Vector3(xTranslation, yTranslation, 0));

        float xDirection = Input.GetAxisRaw($"{playerMeta.InputPrefix}Horizontal");
        float yDirection = Input.GetAxisRaw($"{playerMeta.InputPrefix}Vertical");

        FaceXAxis(xDirection);
        FaceYAxis(yDirection);

        if (xDirection == 0 && yDirection == 0) {
          handAnimator.SetBool("isMoving", false);
        }
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
        handAnimator.SetBool("isMoving", true);

        playerInteraction.transform.localScale = new Vector3(
          xDirection > 0 ? 1 : -1,
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
        handAnimator.SetBool("isMoving", true);

        playerInteraction.transform.localScale = new Vector3(
          playerInteraction.transform.localScale.x,
          yDirection > 0 ? 1 : -1,
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

