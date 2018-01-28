using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fish : MonoBehaviour
{
	[HideInInspector]
	public FishData Data;

	private Transform m_Target;
	private float m_Speed = 0;
	private float m_AttractionDelay = 0;
	private AudioSource Audio = new AudioSource();

	public void HitBySonar(Transform aTarget)
	{
		m_Target = aTarget;
		Audio.clip = Data.SfxWhenHitBySonar;
		Audio.Play();
		m_AttractionDelay = Data.AttractionDuration;
		float distance = Vector3.Distance (transform.position, aTarget.position);
	}

	public void Update()
	{
		if (m_Speed <= 0)
			return;
		
		transform.LookAt (m_Target);

		transform.position += transform.forward * m_Speed;

		float speedDiff = Data.Acceleration * Time.deltaTime;
		if(m_AttractionDelay > 0)
			m_Speed += speedDiff;
		else
			m_Speed -= speedDiff;
			

		m_AttractionDelay -= Time.deltaTime;
	}
}
