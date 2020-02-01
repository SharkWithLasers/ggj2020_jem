using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffsController : MonoBehaviour
{
  public PlayerMovementController movementController;
  public DigController digController;

  private void Start()
  {
    movementController = gameObject.GetComponent<PlayerMovementController>();
    digController = gameObject.GetComponentInChildren<DigController>();
  }

  public void AddBuffs(float speedBuff, float digBuff)
  {
    movementController.IncreaseSpeed(speedBuff);
    digController.IncreaseDigDamage(digBuff);
  }

  public void RemoveBuffs(float speedBuff, float digBuff)
  {
    movementController.DecreaseSpeed(speedBuff);
    digController.DecreaseDigDamage(digBuff);
  }
}
