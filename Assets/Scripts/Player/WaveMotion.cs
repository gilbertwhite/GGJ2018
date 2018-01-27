using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMotion : MonoBehaviour {

	[SerializeField] private Transform Target;
	[SerializeField] private float MinMotionSpeed;
	[SerializeField] private float MaxMotionSpeed;
	[SerializeField] private float MinMotion;
	[SerializeField] private float MaxMotion;
	[SerializeField] private Vector3 Direction;

	[HideInInspector] 
	public float Intensity;

	public void Start()
	{
	}

	public void Update()
	{
		Vector3 waveForce = (Direction * MinMotion) + (Direction * (MaxMotion - MinMotion) * Intensity);
		float waveSpeed = MinMotionSpeed + (MaxMotionSpeed - MinMotionSpeed) * Intensity;
		Target.transform.position += waveForce * Mathf.Sin(Time.time * waveSpeed);
	}
}
