using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScale : MonoBehaviour
{
    [SerializeField] private GameObject barToScale;

    public void UpdateBarLocalScale(float newLocalScale)
    {
        barToScale.transform.localScale = new Vector3(
            newLocalScale,
            barToScale.transform.localScale.y,
            barToScale.transform.localScale.z);
    }
}
