using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
  public static CameraShake Instance;

	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform camTransform;
	
	// How long the object should shake for.
	private float shakeDuration = 0f;
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	private float shakeAmount = 0.5f;
	private float decreaseFactor = 1.0f;
	
	Vector3 originalPos;
	
	void Awake()
	{
    Instance = this;

		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}

  public void Shake(float duration = 0.1f, float amount = 0.5f) {
    shakeAmount = amount;
    shakeDuration = duration;
  }

  public void Stop() {
    shakeDuration = 0;
  }
	
	void OnEnable()
	{
		originalPos = camTransform.localPosition;
	}

	void Update()
	{
		if (shakeDuration > 0)
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			
			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeDuration = 0f;
			camTransform.localPosition = originalPos;
		}
	}
}