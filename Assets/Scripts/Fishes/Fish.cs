using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fish : MonoBehaviour
{
	public FishData Data;

	public void HitBySonar(Transform aTarget)
	{
		Data.SfxWhenHitBySonar.Play();
		float distance = Vector3.Distance (transform.position, aTarget.position);
		transform.LookAt (aTarget);
		transform.DOMove (transform.position + transform.forward * distance, Data.AttractionDuration).SetEase(Ease.InOutQuad); 
	}
}
