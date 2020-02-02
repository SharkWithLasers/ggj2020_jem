using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;


public class GraveAndLoot
{
    public LimbNodeType loot;
    public Grave grave;
}

public class Grave : MonoBehaviour
{
    private LimbNodeType loot = LimbNodeType.LIMB;

    private GraveHealthStatus healthStatus;
    private GraveInteractionStatus interactionStatus;

    private float graveMaxHealth = 100f;
    private float curGraveHealth;
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
            digComponent.SetOverlappinGrave(this);
            numOverlappingPlayers++;
            graveUI.AddBlinkingDigIcon();
            graveUI.AddAndModifyHealthBar(curHealthRatio);
        }
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
        }
    }

    public void Damage(float amount)
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
        var graveAndLoot = new GraveAndLoot
        {
            grave = this,
            loot = loot,
        };
        graveLootedEvent.Raise(graveAndLoot);
    }
}
