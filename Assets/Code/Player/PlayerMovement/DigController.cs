using System.Collections;
using System.Collections.Generic;
using KammBase;
using UnityEngine;

public class DigController : MonoBehaviour
{
    public Animator handAnimator;

    [SerializeField]
    private float digDamagePerPress = 1f;

    [SerializeField]
    private PlayerMeta playerMeta;

    private Option<Grave> overlappingGrave = Option<Grave>.None;
    private bool _isDiggable = false;
    [SerializeField] public PlayerInventory playerInventory;

    public GameObject sfxManager;

    void Update()
    {
        // TODO: Add controller support
        if (Input.GetButtonDown($"{playerMeta.InputPrefix}AButton"))
        {
            TryDig();
        }
        else if (handAnimator.GetBool("isDigging"))
        {
            handAnimator.SetBool("isDigging", false);
        }
    }

    public void TryDig()
    {
        if (overlappingGrave.HasValue && _isDiggable)
        {
            handAnimator.SetBool("isDigging", true);
            overlappingGrave.Value.Damage(digDamagePerPress, playerInventory);
            if (sfxManager != null)
            {
                sfxManager.SendMessage("DigSound");
            }
        }
    }

    public void SetOverlappinGrave(Grave grave, bool isDiggable)
    {
        overlappingGrave = grave;
        _isDiggable = isDiggable;
    }

    public void RemoveOverlappingGrave()
    {
        overlappingGrave = Option<Grave>.None;
        _isDiggable = false;
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
