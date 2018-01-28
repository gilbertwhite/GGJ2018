using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fish : MonoBehaviour
{
	[HideInInspector]
	public FishData Data;
	public float MinDistance = 5f;
	public float MinDistanceRatio = 0.25f;

	private Transform m_Target;
	private float m_AttractionDelay = 0;
	private AudioSource Audio;

	private void Start()
	{
		Audio = gameObject.AddComponent<AudioSource>();
	}

	public void HitBySonar(Transform aTarget)
	{
		m_Target = aTarget;
		if (Data.SfxWhenHitBySonar != null) {
			Debug.Log (Audio + " : " + Data.SfxWhenHitBySonar);
			Audio.clip = Data.SfxWhenHitBySonar;
			Audio.Play ();
		}
		m_AttractionDelay = Data.AttractionDuration;
	}

	public void Update()
	{	
		if (m_Target == null)
			return;
			
		transform.LookAt (m_Target);
		
		float distance = Mathf.Max(MinDistance, Vector3.Distance (transform.position, m_Target.position));
		transform.position += transform.forward * Data.Speed * distance * MinDistanceRatio * Time.deltaTime;

		m_AttractionDelay -= Time.deltaTime;
		if (m_AttractionDelay < 0) {
			m_Target = null;
		}
	}
}
