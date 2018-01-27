using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarCollider : MonoBehaviour 
{


	public void OnTriggerEnter(Collider collider)
	{
		if (collider.tag != "Fish")
			return;

		Fish fish = collider.GetComponent<Fish> ();
		fish.HitBySonar ();
	}
}
