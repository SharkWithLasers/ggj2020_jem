using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
  public float inputDelay = 0.2f;
  public Color unselectedColor;

  [SerializeField]
  public List<MainMenuEntry> selections = new List<MainMenuEntry>();

  private bool canInteract = true;

  private void Start() {
    UpdateSelected(0);
  }

  private void Update()
  {
    if (!canInteract) return;

    float yInput = Input.GetAxisRaw("Player1_Vertical");

    int index = ResolveSelectedIndex();

    if (
      yInput == 0 ||
      index == 0 && yInput > 0 ||
      index == 3 && yInput < 0
    ) return;

    UpdateSelected(
      yInput == 1 ? index - 1 : index + 1,
      index
    );
  }

  private int ResolveSelectedIndex()
  {
    return selections.FindIndex(selection => selection.selected);
  }

  private void UpdateSelected(int selectedIndex, int oldIndex = -1)
  {
    canInteract = false;

    if (oldIndex > -1)
    {
      selections[oldIndex].selected = false;
    }

    selections[selectedIndex].selected = true;

    selections[selectedIndex].item.GetComponentInChildren<Text>().color = Color.white;
    selections[selectedIndex].item.GetComponentInChildren<Image>().enabled = true;

    selections.ForEach(selection => {
      if (!selection.selected)
      {
        selection.item.GetComponentInChildren<Text>().color = unselectedColor;
        selection.item.GetComponentInChildren<Image>().enabled = false;
      }
    });

    StartCoroutine(MenuChange());
  }

  IEnumerator MenuChange()
  {
    yield return new WaitForSeconds(0.25f);
    canInteract = true;   // After the wait is over, the player can interact with the menu again.
  }
}
