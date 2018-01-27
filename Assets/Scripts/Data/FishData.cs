using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishData : ScriptableObject
{
	public string FishType;
	public Color Color = Color.white;
	public Vector3 Scale = Vector3.one;
	public float Speed = 1f;
	[Tooltip("In Seconds")]
	public float AttractionDuration =1f;
}
