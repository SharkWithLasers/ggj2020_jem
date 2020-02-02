using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class InteractableLimbController : MonoBehaviour
{
  InteractButtonController button;
    private bool _canBeFuckedWith;

    private void Start() {
    button = gameObject.GetComponentInChildren<InteractButtonController>();
        _canBeFuckedWith = true;
  }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckForInput(other);
    }

    private void OnTriggerStay2D(Collider2D other)
  {
    CheckForInput(other);
  }

  private void OnTriggerExit2D(Collider2D other) {

  }

  private void CheckForInput(Collider2D other)
  {

    if (_canBeFuckedWith && other.name == "PlayerInteraction")
    {
            _canBeFuckedWith = false;
        LimbNodeController nodeController = gameObject.GetComponent<LimbNodeController>();
        other.GetComponentInChildren<BodyPartController>().AddBodyPartToList(nodeController.limbType);

            //var    

            //gameObject.transform.DOShakePosition(1);
        gameObject.transform.DOScale(1.25f, 0.1f)
                .SetLoops(10, LoopType.Yoyo)
                .OnComplete(() => Destroy(gameObject));
    }
  }
}
