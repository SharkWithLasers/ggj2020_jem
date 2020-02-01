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
            Dig();
        }
    }

    public void Dig()
    {
        Debug.Log("we diggin tho");
        // How does digging work? Perhaps a grave has a trigger, and a player inside that trigger
        // holding the interact button 'digs'
    }

    public void SetOverlappinGrave(Grave grave)
    {
        overlappingGrave = grave;
    }

    public void RemoveOverlappingGrave()
    {
        overlappingGrave = Option<Grave>.None;
    }
}
