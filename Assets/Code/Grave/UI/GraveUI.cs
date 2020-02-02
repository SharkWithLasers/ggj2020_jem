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
    private Vector2 graveHealthBarLocalPosition;
    [SerializeField]
    private GameObject graveHealthBarPrefab;

    private Option<BarScale> curGraveHealthBar = Option<BarScale>.None;

    [SerializeField]
    private Vector2 headRequirementsUI;
    [SerializeField]
    private GameObject headRequirementUIPrefab;

    private Option<GameObject> headReqsGO = Option<GameObject>.None;

    public void AddHeadReqsUI()
    {
        if (!headReqsGO.HasValue)
        {
            headReqsGO = Instantiate(headRequirementUIPrefab, transform);
            headReqsGO.Value.transform.localPosition = headRequirementsUI;
        }
        headReqsGO.Value.SetActive(true);
    }

    public void RemoveHeadReqsUI()
    {
        if (headReqsGO.HasValue)
        {
            headReqsGO.Value.SetActive(false);
        }
    }

    public void AddAndModifyHealthBar(float healthRatio)
    {
        if (!curGraveHealthBar.HasValue)
        {
            var healthBarGO = Instantiate(graveHealthBarPrefab, transform);
            healthBarGO.transform.localPosition = graveHealthBarLocalPosition;
            curGraveHealthBar = healthBarGO.GetComponent<BarScale>();

        }
        curGraveHealthBar.Value.UpdateBarLocalScale(healthRatio);

        curGraveHealthBar.Value.gameObject.SetActive(true);
    }

    public void RemoveHealthBar()
    {
        if (curGraveHealthBar.HasValue)
        {
            curGraveHealthBar.Value.gameObject.SetActive(false);
        }
    }

    public void TryUpdateHealth(float healthRatio)
    {
        if (curGraveHealthBar.HasValue)
        {
            curGraveHealthBar.Value.UpdateBarLocalScale(healthRatio);
        }
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
