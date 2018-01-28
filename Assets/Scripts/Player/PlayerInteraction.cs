using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour 
{
	public float InteractionDistance = 20;

	private void Start()
	{

	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.Return)) {
			TryInteraction();
		}
	}

	private void TryInteraction()
	{
		// Raycast in front of you to hit first Interactable

		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		Ray ray = new Ray(transform.position, fwd);
		if (Physics.Raycast (ray, out hit)) {
			Interactable target = hit.transform.GetComponent<Interactable> ();
			if (target != null)
				OnInteraction (target);
		}
	}

	private void OnInteraction(Interactable aTarget)
	{
		// if Narhwal Tusk ==> Grab it
		// else Interaction Bubble

		Debug.Log ("Interaction With = " + aTarget.gameObject.name);
	}
}
