using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
    if (Input.GetKey(KeyCode.E)
            || Input.GetButtonDown($"Player1_AButton")
            || Input.GetButtonDown($"Player2_AButton"))
    {

        MultiplayerMode();
    }
  }

  private int ResolveSelectedIndex()
  {
    return selections.FindIndex(selection => selection.selected);
  }

  private void SinglePlayerMode()
  {

  }

  private void MultiplayerMode()
  {
        //1 is other scene
        SceneManager.LoadScene(1);
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
