using System.Collections;
using System.Collections.Generic;
using KammBase;
using UnityEngine;

public class DigController : MonoBehaviour
{
    [SerializeField]
    private float digSpeed = 1f;

    [SerializeField]
    private PlayerMeta playerMeta;

    private Option<Grave> overlappingGrave;

    void Update()
    {
        // TODO: Add controller support
        if (Input.GetButtonDown($"{playerMeta.InputPrefix}AButton"))
        {
            TryDig();
        }
    }

    public void TryDig()
    {
        if (overlappingGrave.HasValue)
        {
            Debug.Log("we diggin tho");
        }
    }

    public void SetOverlappinGrave(Grave grave)
    {
        overlappingGrave = grave;
    }

    public void RemoveOverlappingGrave()
    {
        overlappingGrave = Option<Grave>.None;
    }

    public void IncreaseDigSpeed(float modifier)
    {
      digSpeed += modifier;
    }

    public void DecreaseDigSpeed(float modifier)
    {
      digSpeed -= modifier;
    }
}
