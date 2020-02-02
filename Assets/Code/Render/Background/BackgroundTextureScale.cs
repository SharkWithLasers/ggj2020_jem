using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

[RequireComponent(typeof(MeshRenderer))]
public class BackgroundTextureScale : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    [SerializeField]
    private Material toggleMaterial1;

    [SerializeField]
    private Material toggleMaterial2;

    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Setup(Vector2 quadSizeInUnits)
    {
        _meshRenderer = GetComponent<MeshRenderer>();

        toggleMaterial1.mainTextureScale = quadSizeInUnits / 2;
        toggleMaterial2.mainTextureScale = quadSizeInUnits / 2;
        _meshRenderer.material = toggleMaterial1;

        StartCoroutine(KeepOnSwapping());
    }

    private IEnumerator KeepOnSwapping()
    {
        var useMat1 = true;
        while (true)
        {
            _meshRenderer.material = useMat1 ? toggleMaterial1 : toggleMaterial2;
            yield return new WaitForSeconds(0.5f);
            useMat1 = !useMat1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
