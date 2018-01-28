using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleItem : MonoBehaviour {

	public float RotationSpeed = 1.2f;
	public float ScaleAmplitude = 1.2f;
	public float ScaleIntensity = 1.0f;
	private float m_Index = 0;


	private void Update()
	{
		m_Index += Time.deltaTime;
		float value = ScaleAmplitude * Mathf.Cos (ScaleIntensity * m_Index);
		transform.localScale = new Vector3 (value, value, value);

		transform.localEulerAngles += Vector3.up * RotationSpeed;
	}

}
