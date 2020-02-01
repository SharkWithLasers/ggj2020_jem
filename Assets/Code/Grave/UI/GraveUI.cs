using System.Collections;
using System.Collections.Generic;
using KammBase;
using UnityEngine;

public class GraveUI : MonoBehaviour
{
    [SerializeField]
    private GameObject blinkingDigIconPrefab;
    [SerializeField]
    private Vector2 blinkingDigLocalPosition;

    private Option<GameObject> curBlinkingDigIcon = Option<GameObject>.None;

    [SerializeField]
    private GameObject graveHealthBarPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddBlinkingDigIcon()
    {
        if (!curBlinkingDigIcon.HasValue)
        {
            var blinkingDigGO = Instantiate(blinkingDigIconPrefab, transform);
            blinkingDigGO.transform.localPosition = blinkingDigLocalPosition;
            curBlinkingDigIcon = blinkingDigGO;
        }

        curBlinkingDigIcon.Value.SetActive(true);
    }

    public void RemoveBlinkingDigIcon()
    {
        if (curBlinkingDigIcon.HasValue)
        {
            curBlinkingDigIcon.Value.SetActive(false);
        }
    }
}
