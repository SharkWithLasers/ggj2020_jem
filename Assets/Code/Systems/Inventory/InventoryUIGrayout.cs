using UnityEngine;
using UnityEngine.UI;

public class InventoryUIGrayout : MonoBehaviour
{
    private Image _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<Image>();

        _spriteRenderer.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
    }


    public void AddAsInventory()
    {
        _spriteRenderer.color = new Color(1f, 1f, 1f, 1f);

    }
}
