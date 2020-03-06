using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

public class GraveAndLoot
{
    public LimbNodeType loot;
    public Grave grave;
}

public static class GraveConstants
{
    public static Dictionary<LimbNodeType, int> headRequirements = new Dictionary<LimbNodeType, int>
    {
        { LimbNodeType.HAND, 2 },
        { LimbNodeType.FOOT, 2 },
        { LimbNodeType.TORSO, 1 },
        { LimbNodeType.LIMB, 4 },
    };
}

public class Grave : MonoBehaviour
{
    public LimbNodeType loot = LimbNodeType.LIMB;

    // Changed to public to allow access through dig controller, prevent repeated sfx triggering
    public GraveHealthStatus healthStatus;
    private GraveInteractionStatus interactionStatus;

    private float graveMaxHealth = 100f;

    // Changed to public to allow per-character trigger of item get -Evan
    public float curGraveHealth;
    private float curHealthRatio => curGraveHealth / graveMaxHealth;

    private int numOverlappingPlayers = 0;

    [SerializeField]
    private GraveAndLootGameEvent graveLootedEvent;
    
    [SerializeField]
    private GraveUI graveUI;

    // Start is called before the first frame update
    void Start()
    {
        healthStatus = GraveHealthStatus.Untouched;

        curGraveHealth = graveMaxHealth;
    }

    public void SetLoot(LimbNodeType lootLimb)
    {
        loot = lootLimb;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (healthStatus == GraveHealthStatus.CompletelyLooted)
        {
            return;
        }

        var digComponent = collision.gameObject.GetComponent<DigController>();
        if (digComponent != null)
        {

            var isDiggable = GetDiggable(digComponent.playerInventory);

            digComponent.SetOverlappinGrave(this, isDiggable);
            numOverlappingPlayers++;

            if (isDiggable)
            {
                graveUI.AddBlinkingDigIcon();
                graveUI.AddAndModifyHealthBar(curHealthRatio);
            }
            else
            {
                graveUI.AddHeadReqsUI();
            }
        }
    }

    private bool GetDiggable(PlayerInventory playerInventory)
    {
        return true;

        if (loot != LimbNodeType.HEAD)
        {
            return true;
        }

        foreach (var kvp in GraveConstants.headRequirements)
        {
            var headReqType = kvp.Key;
            var headReqCount = kvp.Value;

            if (!playerInventory.bodyPartToCount.ContainsKey(headReqType) ||
                playerInventory.bodyPartToCount[headReqType] < headReqCount)
            {
                return false;
            }
        }

        return true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var digComponent = collision.gameObject.GetComponent<DigController>();
        if (digComponent != null)
        {
            digComponent.RemoveOverlappingGrave();
            numOverlappingPlayers = Mathf.Max(numOverlappingPlayers - 1, 0);
            graveUI.RemoveBlinkingDigIcon();
            graveUI.RemoveHealthBar();
            graveUI.RemoveHeadReqsUI();
        }
    }

    public void Damage(float amount, PlayerInventory playerInventory)
    {
        if (healthStatus == GraveHealthStatus.CompletelyLooted)
        {
            return;
        }

        curGraveHealth = Mathf.Max(0,  curGraveHealth - amount);
        graveUI.TryUpdateHealth(curHealthRatio);

        if (curGraveHealth == 0)
        {
            LootGrave();
        }
    }

    private void LootGrave()
    {
        healthStatus = GraveHealthStatus.CompletelyLooted;
        graveUI.RemoveBlinkingDigIcon();
        graveUI.RemoveHealthBar();
        graveUI.RemoveHeadReqsUI();

        var graveAndLoot = new GraveAndLoot
        {
            grave = this,
            loot = loot,
        };
        graveLootedEvent.Raise(graveAndLoot);
    }
}
