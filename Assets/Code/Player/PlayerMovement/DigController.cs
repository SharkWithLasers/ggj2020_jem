using System.Collections;
using System.Collections.Generic;
using KammBase;
using UnityEngine;

public class DigController : MonoBehaviour
{
    [SerializeField]
    private float digDamagePerPress = 1f;

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
            overlappingGrave.Value.Damage(digDamagePerPress);
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

    public void IncreaseDigDamage(float modifier)
    {
      digDamagePerPress += modifier;
    }

    public void DecreaseDigDamage(float modifier)
    {
      digDamagePerPress -= modifier;
    }
}
