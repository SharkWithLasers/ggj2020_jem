using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private PlayerMeta playerMeta;

    private void Start()
    {
    }

    private void Update()
    {
        float x = Input.GetAxis($"{playerMeta.InputPrefix}Horizontal") * speed;
        float y = Input.GetAxis($"{playerMeta.InputPrefix}Vertical") * speed;

        float xTranslation = x * Time.deltaTime;
        float yTranslation = y * Time.deltaTime;

        transform.Translate(new Vector3(xTranslation, yTranslation, 0));
    }

    public void IncreaseSpeed(float modifier)
    {
        speed += modifier;
    }

    public void DecreaseSpeed(float modifier)
    {
        speed -= modifier;
    }
}

