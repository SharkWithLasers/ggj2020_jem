using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFollowCam : MonoBehaviour
{
    [SerializeField]
    public Transform target;

    [SerializeField]
    public float smoothTime = 0.5f;

    private Vector3 _velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        var targetPosition = new Vector3(
            target.position.x, target.position.y, transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position,
          targetPosition, ref _velocity, smoothTime);
    }
}
