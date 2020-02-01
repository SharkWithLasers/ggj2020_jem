using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{
  public float minSpeedBuff;
  public float maxSpeedBuff;
  public float minDigBuff;
  public float maxDigBuff;

  [HideInInspector]
  public float speedBuff;
  [HideInInspector]
  public float digBuff;


  void Start()
  {
    speedBuff = Random.Range(minSpeedBuff, maxSpeedBuff);
    digBuff = Random.Range(minDigBuff, maxDigBuff);
  }
}
