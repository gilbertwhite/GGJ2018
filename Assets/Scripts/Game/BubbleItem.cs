using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleItem : MonoBehaviour {

	public float Duration = 5f;
	public float RotationSpeed = 1.2f;
	public float DefaultScale = 1.0f;
	public float ScaleAmplitude = 1.2f;
	public float ScaleSpeed = 2f;
	private float m_Index = 0;

	private void OnEnable()
	{
		m_Index = 0;
		UpdateScaling ();
	}

	private void Update()
	{
		m_Index += Time.deltaTime;
		UpdateScaling ();
	}

	private void UpdateScaling()
	{
		float value = DefaultScale + ScaleAmplitude * Mathf.Cos(m_Index * ScaleSpeed);
		transform.localScale = new Vector3 (value, value, value);

		transform.localEulerAngles += Vector3.up * RotationSpeed;
	}

}
