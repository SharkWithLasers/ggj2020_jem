using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grave : MonoBehaviour
{
    private LimbNodeType loot;

    private GraveHealthStatus healthStatus;
    private GraveInteractionStatus interactionStatus;

    private float graveMaxHealth = 100f;
    private float curGraveHealth;

    //private GameObject[] currentOverlappingPlayers;
    private int numOverlappingPlayers = 0;

    // Start is called before the first frame update
    void Start()
    {
        loot = LimbNodeType.LIMB;

        healthStatus = GraveHealthStatus.Untouched;

        curGraveHealth = graveMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var digComponent = collision.gameObject.GetComponent<DigController>();
        if (digComponent != null)
        {
            digComponent.SetOverlappinGrave(this);
            numOverlappingPlayers++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var digComponent = collision.gameObject.GetComponent<DigController>();
        if (digComponent != null)
        {
            digComponent.RemoveOverlappingGrave();
            numOverlappingPlayers--;
        }
    }


}
