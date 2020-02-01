using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grave : MonoBehaviour
{
    private LimbNodeType loot;

    private GraveHealthStatus healthStatus;
    private GraveInteractionStatus interactionStatus;

    private GameObject[] currentOverlappingPlayers;

    /*
    [SerializeField]
    private */
    //private 

    // Start is called before the first frame update
    void Start()
    {
        //graveGUID = new GUID();

        loot = LimbNodeType.LIMB;

        healthStatus = GraveHealthStatus.Untouched;
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
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var digComponent = collision.gameObject.GetComponent<DigController>();
        if (digComponent != null)
        {
            digComponent.RemoveOverlappingGrave();
        }
    }


}
